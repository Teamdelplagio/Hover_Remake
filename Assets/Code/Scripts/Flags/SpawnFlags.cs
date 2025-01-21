using UnityEngine;

public class SpawnFlags : MonoBehaviour
{
    public GameObject blueFlagPrefab;  // Prefab per la bandierina blu
    public GameObject redFlagPrefab;   // Prefab per la bandierina rossa
    public Transform[] spawnPoints;    // Array dei punti di spawn 

    void Start()
    {
        SpawnPoints();
    }

    void SpawnPoints()
    {
        // Lista per memorizzare i colori delle bandierine
        string[] flags = new string[spawnPoints.Length];

        // crea le bandierine
        for (int i = 0; i < 6; i++)
        {
            flags[i] = "blue";
            flags[i + 6] = "red";
        }

        // Mischia l'array per una distribuzione casuale
        Shuffle(flags);

        // Spawn dei punti negli Spawnpoints
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i];  // Ottieni la posizione dello spawn
            GameObject pointPrefab = flags[i] == "blue" ? blueFlagPrefab : redFlagPrefab;  // Scegli il prefab in base al colore
            Instantiate(pointPrefab, spawnPoint.position, Quaternion.identity);  // Instanzia il prefab alla posizione dello spawn
        }
    }

    // Funzione per mischiare un array
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
}
