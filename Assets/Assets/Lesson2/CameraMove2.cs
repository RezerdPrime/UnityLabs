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
            offset = new Vector3(1f, 5f, 1f);
            transform.position = player.position + offset;
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
