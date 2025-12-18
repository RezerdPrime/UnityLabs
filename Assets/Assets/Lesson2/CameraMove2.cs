using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 5f;

    void Start()
    {
        if (player != null)
        {
            offset = new Vector3(0f, 4f, -2f);
            transform.position = player.position + offset;
            //transform.rotation = new Quaternion(20f, 0f, 0f);
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Целевая позиция камеры
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
