using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    //public float speed = 9.0f;  // Speed of the AI movement
    //public float turnSpeed = 85.0f;  // Speed of turning
    //public float detectionRange = 10f;  // How far the AI will detect a target

    //private Transform target;
    //private bool isChasing = false;

    //void Update()
    //{
    //    // If the AI is not chasing, move forward randomly
    //    if (!isChasing)
    //    {
    //        MoveForward();
    //    }

    //    // Optional: Add basic detection for a target (like the player)
    //    CheckForTarget();

    //    // If the target is within detection range, start chasing
    //    if (isChasing && target != null)
    //    {
    //        ChaseTarget();
    //    }
    //}

    //void MoveForward()
    //{
    //    // Move the AI forward
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);

    //    // Rotate the AI randomly on Y-axis (to simulate random movement)
    //    transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * Random.Range(0.5f, 1f));
    //}

    //void CheckForTarget()
    //{
    //    // Here you would check for the target (like the player)
    //    // For simplicity, we're using the player tag to find the player
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    if (player != null)
    //    {
    //        // Calculate distance to the player
    //        float distance = Vector3.Distance(transform.position, player.transform.position);

    //        // If the player is within detection range, start chasing
    //        if (distance < detectionRange)
    //        {
    //            isChasing = true;
    //            target = player.transform;
    //        }
    //        else
    //        {
    //            isChasing = false;
    //        }
    //    }
    //}

    //void ChaseTarget()
    //{
    //    // Move towards the target (player)
    //    Vector3 direction = (target.position - transform.position).normalized;
    //    transform.Translate(direction * speed * Time.deltaTime);

    //    // Optionally, rotate the AI to face the target
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    //}

    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent NavMeshAgent;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        NavMeshAgent .SetDestination(target.position);
    }

}
