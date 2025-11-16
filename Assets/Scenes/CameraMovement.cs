
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float cameraFollowSpeed = 2f;

    void Start()
    {
        if (Player != null)
        {
            offset = new Vector3(0, 9, -6);
            transform.position = Player.position + offset;
        }
    }

    // test

    void Update()
    {
        if (Player == null) return;

        Vector3 targetPosition = Player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);

    }

}
