using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private float direction = 1f;

    void Update()
    {
        // Move the obstacle up and down
        transform.Translate(Vector2.up * speed * direction * Time.deltaTime);

        // Change direction when it reaches the top or bottom
        if (transform.position.y >= distance || transform.position.y <= -distance)
        {
            direction *= -1f; // Reverse direction
        }
    }
}
