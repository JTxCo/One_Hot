using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 2f; // Speed of the target movement
    public float moveRange = 10f; // Range of movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Adjust the movement logic to account for the time scale
        float adjustedSpeed = speed * Time.timeScale; // Adjust speed based on time scale
        float move = Mathf.PingPong(Time.time * adjustedSpeed, moveRange) - (moveRange / 2);
        transform.position = startPosition + new Vector3(move, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy the target
    }
}
