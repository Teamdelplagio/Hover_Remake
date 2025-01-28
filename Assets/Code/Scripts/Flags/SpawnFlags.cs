using UnityEngine;

public class SpawnFlags : MonoBehaviour
{
    public GameObject blueFlagPrefab;  // Prefab per la bandierina blu
    public GameObject redFlagPrefab;   // Prefab per la bandierina rossa
    public Transform[] spawnPoints;    // Array dei punti di spawn 
    [SerializeField] private int amount = 1;


    void Start()
    {
        SpawnPoints();
    }

    void SpawnPoints()
    {
        // lista per memorizzare i colori delle bandierine
        string[] flags = new string[spawnPoints.Length];

        // crea le bandierine
        for (int i = 0; i < 6; i++)
        {
            flags[i] = "blue";
            flags[i + 6] = "red";
        }

        // mischia l'array in modo casuale
        Shuffle(flags);

        // spawn dei punti negli Spawnpoints
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i];  // ottiene la posizione dello spawn
            GameObject pointPrefab = flags[i] == "blue" ? blueFlagPrefab : redFlagPrefab;  // sceglie il prefab in base al colore
            Instantiate(pointPrefab, spawnPoint.position, Quaternion.identity);  // crea il prefab nella posizione dello spawn
        }
    }

    // funzione per mischiare un array
    void Shuffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            string temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }


    
    /*
    //se le bandiere collidono con qualcos'altro, aumenta il punteggio e si disattivano
    private void OnTriggerEnter3D(Collider other)
    {
        // ScoreManager manager = other.GetComponent< ScoreManager >();
        //
        // if ( manager )
        // {
        //     manager.AddScore(amount);
        // }

        if (other.TryGetComponent(out ScoreManager manager))
        {
            manager.AddScore(amount);
            gameObject.SetActive(false);
        }
    }*/
}
