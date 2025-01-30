//using UnityEngine;
//using UnityEngine.AI;

//[System.Serializable]
//public class EnemyFlags : EnemyState
//{
//    // Usa l'array TakeFlag dal controller
//    private Transform currentFlag;
//    private int _currentFlagIndex = 0;

//    // Metodo per trovare la bandiera successiva
//    void FindNextFlag(EnemyController _controller)
//    {
//        // Se non ci sono bandiere, non fare nulla
//        if (_controller.TakeFlag.Length == 0) return;

//        // Passa alla bandiera successiva (ciclo continuo)
//        _currentFlagIndex = (_currentFlagIndex + 1) % _controller.TakeFlag.Length;
//        currentFlag = _controller.TakeFlag[_currentFlagIndex];
//    }

//    // Metodo che viene chiamato quando entriamo nello stato
//    public override void OnEnter(EnemyController _controller)
//    {
//        Debug.Log($"Destinazione corrente: {currentFlag.position}");
//        // Verifica che ci siano bandiere
//        if (_controller.TakeFlag.Length == 0)
//        {
//            _currentFlagIndex = (_currentFlagIndex + 1) % _controller.TakeFlag.Length;
//            currentFlag = _controller.TakeFlag[_currentFlagIndex];

//            Debug.LogWarning("Nessuna bandiera disponibile!");
//            return;
//        }

//        // Trova la bandiera più vicina all'inizio
//        float closestDistance = float.MaxValue;

//        for (var index = 0; index < _controller.TakeFlag.Length; index++)
//        {
//            var flag = _controller.TakeFlag[index];
//            float distance = Vector3.Distance(_controller.transform.position, flag.position);

//            // Trova la bandiera più vicina
//            if (distance < closestDistance)
//            {
//                closestDistance = distance;
//                _currentFlagIndex = index;
//            }
//        }

//        // Imposta la bandiera corrente come la bandiera più vicina
//        currentFlag = _controller.TakeFlag[_currentFlagIndex];

//        // Imposta la destinazione dell'agente alla bandiera trovata
//        _controller.Agent.SetDestination(currentFlag.position);
//    }

//    // Metodo che viene chiamato ogni frame mentre lo stato è attivo
//    public override void OnUpdate(EnemyController _controller)
//    {
//        Debug.Log($"Destinazione corrente: {currentFlag.position}");

//        // Controlla se l'agente ha raggiunto la bandiera corrente (distanza diretta con la bandiera)
//        //if (Vector3.Distance(_controller.transform.position, currentFlag.position) < 0.1f)
//        if (_controller.Agent.remainingDistance <= _controller.Agent.stoppingDistance)

//        {
//                // Se la bandiera corrente è stata raggiunta, trova la bandiera successiva
//                FindNextFlag(_controller);

//            // Imposta la nuova destinazione per l'agente
//            _controller.Agent.SetDestination(currentFlag.position);
//        }
//    }

//    // Metodo che viene chiamato quando esci dallo stato
//    public override void OnExit(EnemyController _controller)
//    {
//    }

//    // Metodo che gestisce le collisioni
//    public override void OnCollision(EnemyController _controller, Collider _collision)
//    {
//        // Se l'agente collide con la bandiera corrente
//        if (_collision.transform == currentFlag)
//        {
//            // Passa allo stato di pattuglia
//            _controller.SetState(_controller.PatrolState);
//        }
//    }

//    // Metodo per il debug: disegna gizmos nella scena per visualizzare le bandiere
//    public override void DrawGizmo(EnemyController _controller)
//    {
//        // Disegna le bandiere nella scena per il debug
//        if (_controller.TakeFlag.Length > 0)
//        {
//            foreach (var flag in _controller.TakeFlag)
//            {
//                if (flag != null)
//                {
//                    Gizmos.color = Color.red;
//                    Gizmos.DrawSphere(flag.position, 0.2f);
//                }
//            }
//        }
//    }
//}

using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyFlags : EnemyState
{
    private Transform currentFlag;
    private bool hasFlag = false; // Se il nemico ha preso la bandiera
    private float flagInteractionDistance = 1f; // Distanza per interagire con la bandiera

    // Metodo che viene chiamato quando entriamo nello stato
    public override void OnEnter(EnemyController _controller)
    {
        // Assicurati che ci sia una bandiera disponibile
        if (_controller.TakeFlag != null && _controller.TakeFlag.Length > 0)
        {
            // Imposta la bandiera corrente come la prima bandiera disponibile
            currentFlag = _controller.TakeFlag[0];
            Debug.Log($"Entrato nello stato FlagState, obiettivo: {currentFlag.position}");
            _controller.Agent.SetDestination(currentFlag.position); // Imposta la destinazione alla bandiera
        }
        else
        {
            Debug.LogWarning("Nessuna bandiera disponibile, passando a PatrolState.");
            _controller.SetState(_controller.PatrolState); // Se non c'è bandiera, passa al pattugliamento
        }
    }

    // Metodo che viene chiamato ogni frame mentre lo stato è attivo
    public override void OnUpdate(EnemyController _controller)
    {
        if (currentFlag == null) return;

        // Controlla se il nemico è vicino abbastanza alla bandiera per interagire
        if (Vector3.Distance(_controller.transform.position, currentFlag.position) <= flagInteractionDistance)
        {
            if (!hasFlag)
            {
                // Il nemico raccoglie la bandiera
                Debug.Log("Bandiera raccolta!");
                hasFlag = true;

                // Dopo aver preso la bandiera, il nemico passa direttamente allo stato di pattuglia
                _controller.SetState(_controller.PatrolState);
            }
        }
    }

    // Metodo che viene chiamato quando esci dallo stato
    public override void OnExit(EnemyController _controller)
    {
        // Puoi aggiungere logiche di uscita se necessarie (ad esempio fermare alcune animazioni)
        Debug.Log("Uscito dallo stato FlagState.");
        _controller.SetState(_controller.PatrolState);
    }

    // Metodo che gestisce le collisioni
    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
        // Se l'agente collide con la bandiera corrente
        if (_collision.transform == currentFlag)
        {
            // passa allo stato di pattuglia
            _controller.SetState(_controller.PatrolState);
        }
    }

    // Metodo per il debug: disegna gizmos nella scena per visualizzare la bandiera
    public override void DrawGizmo(EnemyController _controller)
    {
        if (currentFlag != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(currentFlag.position, flagInteractionDistance);
        }
    }
}
