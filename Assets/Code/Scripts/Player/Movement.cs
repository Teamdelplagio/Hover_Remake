using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
    
{

    public float speed = 5f;               // Player movement speed
    public float turnSpeed = 100f;         // Speed at which the player turns
    public float gravity = -9.8f;          // Gravity applied to the player

    private Rigidbody _rigidbody;
    private Vector3 velocity;              // To handle movement velocity

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirectionX = Input.GetAxis("Horizontal");

        // Handle player rotation (rotate towards the movement direction)
        if (moveDirectionX != 0)
        {
            Vector3 toRotation = transform.rotation.eulerAngles;  // Create a rotation to face the direction of movement
            toRotation.y += moveDirectionX * turnSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler (toRotation), turnSpeed * Time.deltaTime);  // Rotate smoothly
        }
    }

    private void FixedUpdate()
    {
        // Get input from the player (WASD)
        float moveDirectionZ = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 move = /*transform.right * moveDirectionX + */transform.forward * moveDirectionZ;

        // Apply movement
        _rigidbody.AddForce(move * speed);
    }
}

