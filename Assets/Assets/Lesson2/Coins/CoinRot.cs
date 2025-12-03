using UnityEngine;
using UnityEngine.Rendering;

public class CoinRot : MonoBehaviour
{
    [SerializeField] private float rotspeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotspeed * Time.deltaTime, 0, 0);
    }
}
