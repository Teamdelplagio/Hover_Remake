using UnityEngine;

[System.Serializable]
public class EnemyPatrol : EnemyState
{
    [SerializeField] private float playerSightRadius = 20f;
    [SerializeField] private float flagSightRadius = 5f;

    private int _currentIndex = 0;

    public override void OnEnter(EnemyController _controller)
    {
        float closestDistance = float.MaxValue;

        for (var index = 0; index < _controller.PatrolPoints.Length; index++)
        {
            var patrolPoint = _controller.PatrolPoints[index];

            float distance = Vector3.Distance(_controller.transform.position, patrolPoint.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                _currentIndex = index;
            }
        }

        //_controller.Agent.SetDestination(_controller.PatrolPoints[_currentIndex].position);
    }

    public override void OnUpdate(EnemyController _controller)
    {
        if (Vector3.Distance(_controller.transform.position, _controller.Agent.destination) < 1f)
        {
            _currentIndex += 1;

            if (_currentIndex >= _controller.PatrolPoints.Length)
            {
                _currentIndex = 0;
            }

            _controller.Agent.SetDestination(_controller.PatrolPoints[_currentIndex].position);
        }

        if (Vector3.Distance(_controller.transform.position, _controller.PlayerTransform.position) < playerSightRadius)
        {
            _controller.SetState(_controller.ChaseState);
        }

        //if (Vector3.Distance(_controller.transform.position, _controller.TakeFlag[0].position) < playerSightRadius)
        //{
        //    _controller.SetState(_controller.FlagState);
        //}

        // Se una bandiera è nel raggio di visibilità, passa allo stato FlagState
        for (int i = 0; i < _controller.TakeFlag.Length; i++)
        {
            if (_controller.TakeFlag[i] != null)
            {
                float distanceToFlag = Vector3.Distance(_controller.transform.position, _controller.TakeFlag[i].position);

                if (distanceToFlag <= flagSightRadius)
                {
                    // Passa allo stato FlagState se una bandiera è nel raggio di visibilità
                    Debug.Log("Bandiera nel raggio di visibilità, passo a FlagState.");
                    _controller.SetState(_controller.FlagState);
                    return; // Evita di continuare l'aggiornamento in ChaseState
                }
            }
        }
    }
    public override void OnExit(EnemyController _controller)
    {
    }

    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
    }

    public override void DrawGizmo(EnemyController _controller)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_controller.transform.position, playerSightRadius);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_controller.transform.position, flagSightRadius);
    }
}
