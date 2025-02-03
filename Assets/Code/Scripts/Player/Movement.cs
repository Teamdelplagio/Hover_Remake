using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
    
{

    public float speed = 11f;               // Player movement speed
    public float turnSpeed = 12f;         // Speed at which the player turns
    public float gravity = 0f;          // Gravity applied to the player


    private float originalSpeed;           // To store the original speed for resetting
    private bool isSpeedBoosted = false;   // To check if the speed boost is active
//  private float speedBoostDuration = 5f; // How long the speed boost lasts
    private float speedBoostTimer = 0f;    // Timer for speed boost
    
    private Rigidbody _rigidbody;
    private Vector3 velocity;              // To handle movement velocity

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
            originalSpeed = speed; // Store the original speed
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

        // Handle speed boost timer
        if (isSpeedBoosted)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0f)
            {
                ResetSpeed(); // Reset speed after the boost duration
            }
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

    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        speed += boostAmount; // Increase the speed
        isSpeedBoosted = true;
        speedBoostTimer = duration; // Set the duration of the speed boost
    }

    private void ResetSpeed()
    {
        speed = originalSpeed; // Reset the speed back to original
        isSpeedBoosted = false;
    }

}

