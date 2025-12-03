
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float positionFollowSpeed;
    [SerializeField] private float rotationFollowSpeed;

    private Quaternion cameraRotationOffset;

    void Start()
    {
        if (Player != null)
        {
            offset = new Vector3(0, 1, -4);
            positionFollowSpeed = 2f;
            rotationFollowSpeed = 3f;

            cameraRotationOffset = Quaternion.Euler(offset);

            transform.position = Player.position + offset;
            transform.LookAt(Player);
        }
    }

    void Update()
    {
        if (Player == null) return;

        Vector3 targetPosition = Player.position + Player.rotation * offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            positionFollowSpeed * Time.deltaTime
        );

        Quaternion targetRotation = Quaternion.LookRotation(
            Player.forward,
            Vector3.up
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationFollowSpeed * Time.deltaTime
        );


    }
}
