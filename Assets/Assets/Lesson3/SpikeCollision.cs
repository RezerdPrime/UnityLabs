using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private Color origColor;
    private Renderer playerRend;

    private void Start()
    {
        playerRend = GetComponent<Renderer>();
        origColor = playerRend.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spike"))
        {
            playerRend.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("spike"))
        {
            playerRend.material.color = origColor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            playerRend.material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            playerRend.material.color = origColor;
        }
    }
}
