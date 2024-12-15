using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed at which the obstacle moves
    public float moveRange = 5f;  // The range the obstacle moves within (left and right)
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the obstacle
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the obstacle back and forth
        float newXPosition = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(initialPosition.x + newXPosition, transform.position.y, transform.position.z);
    }
}
