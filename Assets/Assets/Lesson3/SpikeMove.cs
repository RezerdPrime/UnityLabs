using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public float downHeight = -1f; // Насколько опускается шип
    public float upHeight = 0f;     // Исходная позиция
    public float moveSpeed = 5f;    // Скорость движения
    public float waitTimeDown = 1f; // Время внизу
    public float waitTimeUp = 2f;   // Время наверху

    private Vector3 targetPosition;
    private float timer;
    private bool isMovingDown = false;
    private bool isMoving = false;

    void Start()
    {
        moveSpeed = 5f;

        upHeight = transform.position.y;
        targetPosition = transform.position;

        StartMovingDown();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (isMovingDown && timer >= waitTimeDown)
            {
                StartMovingUp();
            }
            else if (!isMovingDown && timer >= waitTimeUp)
            {
                StartMovingDown();
            }
        }
    }

    void StartMovingDown()
    {
        isMovingDown = true;
        isMoving = true;
        targetPosition = new Vector3(transform.position.x, downHeight, transform.position.z);
    }

    void StartMovingUp()
    {
        isMovingDown = false;
        isMoving = true;
        targetPosition = new Vector3(transform.position.x, upHeight, transform.position.z);
    }

}

