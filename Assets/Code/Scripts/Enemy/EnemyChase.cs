using UnityEngine;

[System.Serializable]
public class EnemyChase : EnemyState
{
    [SerializeField] private float chaseRadius = 20f;

    public override void OnEnter(EnemyController _controller)
    {
        _controller.Agent.SetDestination(_controller.PlayerTransform.position);
    }

    public override void OnUpdate(EnemyController _controller)
    {
        float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerTransform.position);

        _controller.Agent.SetDestination(_controller.PlayerTransform.position);

        if (distanceToPlayer > chaseRadius)
        {
            _controller.SetState(_controller.PatrolState);
        }
    }

    public override void OnExit(EnemyController _controller)
    {
    }

    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
        EnemyController enemyController = _collision.GetComponent<EnemyController>();

        //if (enemyController)
        //{
        //    Debug.Log("Collided with player!");
        //}
    }

    public override void DrawGizmo(EnemyController _controller)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_controller.transform.position, chaseRadius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(_controller.transform.position, _controller.PlayerTransform.position);
    }
}
