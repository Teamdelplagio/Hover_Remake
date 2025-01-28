using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyFlags : EnemyState
{
    public Transform[] flags; // Flags to follow
    private Transform currentFlag;
    private int _currentFlagIndex = 0;

    public class PickFlagState
    {

    }

    void FindNextFlag()
    {
        // Ensure there are flags available
        if (flags.Length == 0) return;

        // Get the flag
        currentFlag = flags[_currentFlagIndex];
        _currentFlagIndex = (_currentFlagIndex + 1) % flags.Length;
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
        }
    }
    public override void OnUpdate(EnemyController _controller)
    {
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
        if (Vector3.Distance(_controller.transform.position, _controller.Agent.destination) < 0.1f) // NOPE
        {
            _controller.SetState(_controller.PatrolState);
        }

        //if con player (forse)
    }

    public override void DrawGizmo(EnemyController _controller)
    {
    }


}
