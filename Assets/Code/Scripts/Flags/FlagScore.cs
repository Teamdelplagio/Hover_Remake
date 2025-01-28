using UnityEngine;

public class FlagScore : MonoBehaviour
{
    [SerializeField] private int amount = 1;

    //se le bandiere collidono con qualcos'altro, aumenta il punteggio e si disattivano
    private void OnTriggerEnter(Collider other)
    {

         
        // ScoreManager manager = other.GetComponent< ScoreManager >();
        //
        // if ( manager )
        // {
        //     manager.AddScore(amount);RC
        // }

        if (other.TryGetComponent(out ScoreManager manager))
        {
            manager.AddScore(amount);
            gameObject.SetActive(false);
        }
    }
}
