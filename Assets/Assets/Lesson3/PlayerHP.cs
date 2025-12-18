using System.Collections;
using Unity.VisualScripting;

//using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;
    [SerializeField] public float curHP;
    [SerializeField] private bool Invinc = false;
    [SerializeField] private float InvincTime = 1f;

    [SerializeField] private GameObject Tesla;

    private Renderer playerRenderer;
    private Renderer sphereRenderer;
    private Renderer cloudRenderer;

    private Color origColor;
    private Color sphereOrigColor;
    private Color cloudOrigColor;

    private bool poisoned = false;
    private bool inElectricField = false;
    private float timer = 0f;
    private float timerIEF = 0f;

    //private int poisonticks = 3;

    void Start()
    {
        curHP = maxHP;
        playerRenderer = GetComponent<Renderer>();
        origColor = playerRenderer.material.color;

        Transform shp = Tesla.transform.Find("Sphere");
        sphereRenderer = shp.GetComponent<Renderer>();
        sphereOrigColor = new Color(0.3f, 0.3f, 0.3f, 50f / 255f);

        Transform ecl = Tesla.transform.Find("ElectricCloud");
        cloudRenderer = ecl.GetComponent<Renderer>();
        cloudOrigColor = new Color(0f, 1f, 1f, 0f);

        sphereRenderer.sharedMaterial.color = sphereOrigColor;
        cloudRenderer.sharedMaterial.color = cloudOrigColor;

        //Debug.Log($"{sphereRenderer.sharedMaterial.color}");


        //cloudOrigColor = cloudRenderer.material.color;

        //if (shp == null) Debug.Log("Ne pashet");
        //else Debug.Log("pashet");
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerIEF += Time.deltaTime;

        //Debug.Log($"{timer}");

        if (poisoned)
        {
            if ((timer > 1.5) && (timer < 2.5))
            {
                Damage(5, Color.magenta);
            }
            else if ((timer > 3) && (timer < 4))
            {
                Damage(5, Color.magenta);
            }
            else if ((timer > 4.5) && (timer < 5))
            {
                Damage(5, Color.magenta);
                poisoned = false;
            }
        }

        if (timer > 5)
        {
            timer = 0;
        }

        if (inElectricField)
        {
            //Debug.Log($"{timerIEF}");

            if (timerIEF < 4)
            {
                sphereRenderer.sharedMaterial.color = Color.Lerp(
                    sphereOrigColor,
                    new Color(0f, 1f, 1f, 50f / 255f),
                    timerIEF / 4f
                    );

                //sphereRenderer.sharedMaterial.color = Color.Lerp(
                //    sphereOrigColor,
                //    new Color(0.3f, 0.3f, 0.3f, 50f / 255f),
                //    timerIEF / 4f
                //    );
            }

            else if (timerIEF > 4 && timerIEF < 4.5)
            {
                //timerIEF = 0;
                sphereRenderer.sharedMaterial.color = sphereOrigColor;
                cloudRenderer.sharedMaterial.color = new Color(0f, 1f, 1f, 0.3f);
                Damage(50, Color.red);
            }

            else if (timerIEF > 4.5 && timerIEF < 5.5)
            {

                GetComponent<MoveLab>().enabled = false;

                cloudRenderer.sharedMaterial.color = Color.Lerp(
                    new Color(0f, 1f, 1f, 0.3f),
                    new Color(0f, 1f, 1f, 0.001f),
                    timerIEF - 4.5f
                    );
            }

            else if (timerIEF > 5.5) GetComponent<MoveLab>().enabled = true;
        }



        //if (timer > 20f)
        //{
        //    playerRenderer.material.color = Color.blue;
        //}

        //if (timer > 40f)
        //{
        //    playerRenderer.material.color = Color.yellow;
        //    timer = 0;
        //}

        if (Input.GetKeyDown(KeyCode.R) && (curHP == 0f))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Damage(float damage, Color color)
    {
        if (curHP > 0)
        {
            if (Invinc) return;
            curHP -= damage;

            if (curHP <= 0)
            {
                curHP = 0;
                playerRenderer.material.color = Color.red;
                Die();
            }

            StartCoroutine(Invincibility(color));
        }
    }



    IEnumerator Invincibility(Color color)
    {
        Invinc = true;
        playerRenderer.material.color = color;

        yield return new WaitForSeconds(InvincTime);

        Invinc = false;
        playerRenderer.material.color = origColor;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("spike")) Damage(10, Color.red);
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("spike")) Damage(15, Color.red);

        if (collision.gameObject.CompareTag("toxicspike")) { 
            Damage(10, Color.magenta);
            poisoned = true;
            timer = 0;
        }

        //if (collision.gameObject.CompareTag("elcloud")) { 
        //    inElectricField = true;
        //    timerIEF = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("elcloud"))
        {
            inElectricField = true;
            timerIEF = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("elcloud"))
        {
            inElectricField = false;
            sphereRenderer.sharedMaterial.color = sphereOrigColor;
        }
    }

    private void Die()
    {
        GetComponent<MoveLab>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        float targetRot = transform.eulerAngles.z + 90;
        float curRot = transform.eulerAngles.z;

        float duration = 10f;
        float time = 0f;

        while (time < duration) { 
            time += Time.deltaTime;
            float t = time / duration;

            float newRot = Mathf.Lerp(curRot, targetRot, t);
            transform.rotation = Quaternion.Euler(0, 0, newRot);
        }
    }

}
