using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector3 startingPosition { get; private set; }
    public Vector2 direction { get; private set; }
    public float speedMultiplier = 1.0f;
    public float speed = 8.0f;
    public Vector2 initialDirection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void SetDirection(Vector2 direction)
    {
            this.direction = direction;
    }


    private void FixedUpdate() // fixedupdate instead of update to compensate for FPS variations
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }
    public void ResetState() // reset movement properties
    {
        speedMultiplier = 1.0f;
        direction = initialDirection;
        transform.position = startingPosition;
        enabled = true;
    }

}