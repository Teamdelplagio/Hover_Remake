using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyFlags : EnemyState
{
    public Transform[] flags; // Flags to follow
    private Transform currentFlag;
    private int _currentFlagIndex = 0;

    void FindNextFlag()
    {
        // Ensure there are flags available
        if (flags.Length == 0) return;

        // Move to the next flag
        _currentFlagIndex = (_currentFlagIndex + 1) % flags.Length;
        currentFlag = flags[_currentFlagIndex];
    }

    public override void OnEnter(EnemyController _controller)
    {
        float closestDistance = float.MaxValue;

        for (var index = 0; index < _controller.TakeFlag.Length; index++)
        {
            var flag = _controller.TakeFlag[index];

            float distance = Vector3.Distance(_controller.transform.position, flag.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                _currentFlagIndex = index;
            }
            //currentFlag = _controller.TakeFlag[_currentFlagIndex];
            //_controller.Agent.SetDestination(currentFlag.position);
        }
    }
    public override void OnUpdate(EnemyController _controller)
    {
        // If the enemy is close enough to the flag, move to the next flag
        //if (Vector3.Distance(_controller.transform.position, currentFlag.position) < 0.1f)
        //{
        //    FindNextFlag();
        //    _controller.Agent.SetDestination(currentFlag.position); // Move to next flag
        //}
        if (Vector3.Distance(_controller.transform.position, _controller.Agent.destination) < 0.1f)
        {
            FindNextFlag();
        }
    }

    public override void OnExit(EnemyController _controller)
    {
    }

    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
        //if con bandiere (principale)
        if (_collision.transform == currentFlag)
        {
            _controller.SetState(_controller.PatrolState);
        }

        //if con player (forse)
    }

    public override void DrawGizmo(EnemyController _controller)
    {
    }

    //public override void OnEnter(EnemyController _controller)
    //{
    //    // Find the closest flag
    //    float closestDistance = float.MaxValue;

    //    for (var index = 0; index < _controller.TakeFlag.Length; index++)
    //    {
    //        var flag = _controller.TakeFlag[index];
    //        float distance = Vector3.Distance(_controller.transform.position, flag.position);

    //        if (distance < closestDistance)
    //        {
    //            closestDistance = distance;
    //            _currentFlagIndex = index;
    //        }
    //    }

    //    // Set destination to the closest flag
    //    currentFlag = _controller.TakeFlag[_currentFlagIndex];
    //    _controller.Agent.SetDestination(currentFlag.position);
    //}

}
