using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [field: SerializeField, Header("Patrol Settings")]
    public Transform[] PatrolPoints { get; private set; }
    [field: SerializeField] public EnemyPatrol PatrolState { get; private set; }

    [field: SerializeField, Header("Chase Settings")]
    public Transform PlayerTransform { get; private set; }
    [field: SerializeField] public EnemyChase ChaseState { get; private set; }

    //[field: SerializeField, Header("Flag Settings")]
    //public Transform[] FlagsTransform { get; private set; }
    //[field: SerializeField] public EnemyFlags FlagState { get; private set; }

    public NavMeshAgent Agent { get; private set; }

    private EnemyState _currentState;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        SetState(PatrolState);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnUpdate(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_currentState != null) _currentState.OnCollision(this, other);
    }

    public void SetState(EnemyState _state)
    {
        if (_state == null) return;

        if (_currentState != null)
            _currentState.OnExit(this);

        _currentState = _state;

        _currentState.OnEnter(this);
    }

    private void OnDrawGizmos()
    {
        if (_currentState != null) _currentState.DrawGizmo(this);
    }
}
