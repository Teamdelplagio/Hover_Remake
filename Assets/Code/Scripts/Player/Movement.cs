using UnityEngine;

public class Movement : MonoBehaviour
    
{

    public float speed = 5f;               // Player movement speed
    public float turnSpeed = 100f;         // Speed at which the player turns
    public float gravity = -9.8f;          // Gravity applied to the player

    private CharacterController characterController;
    private Vector3 velocity;              // To handle movement velocity

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  // Get the CharacterController component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player (WASD keys or arrow keys)
        float moveDirectionZ = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");

        // Create a movement vector based on input
        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        // Apply movement
        characterController.Move(move * speed * Time.deltaTime);

        // Handle player rotation (rotate towards the movement direction)
        if (moveDirectionZ != 0 || moveDirectionX != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);  // Create a rotation to face the direction of movement
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);  // Rotate smoothly
        }
    }
}

