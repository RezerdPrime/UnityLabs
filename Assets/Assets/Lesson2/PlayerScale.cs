using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
