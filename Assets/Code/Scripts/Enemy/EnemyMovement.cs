using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIMovement : MonoBehaviour
{
    //public Transform[] flags; // Flags to follow
    //private Transform currentFlag;
    private int currentFlagIndex = 0;
    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

    }







    //void Start()
    //{
    //    FindNextFlag();
    //}

    //void Update()
    //{
    //    if (Vector3.Distance(transform.position, currentFlag.position) < 2f)
    //    {
    //        FindNextFlag();
    //    }

    //    // Go to the current flag
    //    NavMeshAgent.SetDestination(currentFlag.position);
    //}

    //void FindNextFlag()
    //{
    //    // Ensure there are flags available
    //    if (flags.Length == 0) return;

    //    // Get the next flag in the array
    //    currentFlag = flags[currentFlagIndex];
    //    currentFlagIndex = (currentFlagIndex + 1) % flags.Length;
    //}
}
