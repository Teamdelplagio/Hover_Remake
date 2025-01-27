using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform target; // Player
    public NavMeshAgent NavMeshAgent;
    public Transform[] flags; // Flags to follow
    private Transform currentFlag;
    private int currentFlagIndex = 0;


    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        FindNextFlag();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentFlag.position) < 2f)
        {
            FindNextFlag();
        }

        // Go to the current flag
        NavMeshAgent.SetDestination(currentFlag.position);

        // If is too close to the player, chase the player
        if (Vector3.Distance(transform.position, target.position) < 5f)
        {
            NavMeshAgent.SetDestination(target.position);
        }
    }

    void FindNextFlag()
    {
        // Ensure there are flags available
        if (flags.Length == 0) return;

        // Get the next flag in the array
        currentFlag = flags[currentFlagIndex];
        currentFlagIndex = (currentFlagIndex + 1) % flags.Length;
    }
}
