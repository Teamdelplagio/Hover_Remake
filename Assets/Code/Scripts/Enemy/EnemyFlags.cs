using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyFlags : EnemyState
{
    [SerializeField] private float flagRadius = 20f;

    public override void OnEnter(EnemyController _controller)
    {
        //_controller.Agent.SetDestination(_controller.FlagsTransform.position);
    }
    SpawnFlags spawnFlags;
    public override void OnUpdate(EnemyController _controller)
    {
        //float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.FlagsTransform.position);

        //_controller.Agent.SetDestination(CompareTag("Flags"));

        GameObject flag = GameObject.FindGameObjectWithTag("Flags");

        if (flag != null)
        {
            // Set destination to the position of the flag
            _controller.Agent.SetDestination(flag.transform.position);
        }
    }
    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
        EnemyController enemyController = _collision.GetComponent<EnemyController>();

        //_controller.SetState(_controller.PatrolState);
    }
    public override void OnExit(EnemyController _controller)
    {
    }

    public override void DrawGizmo(EnemyController _controller)
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_controller.transform.position, flagRadius);
    }
}