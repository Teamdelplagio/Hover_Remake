using UnityEngine;

public class FlagScore_E : MonoBehaviour
{
    [SerializeField] private int amount = 1;

    //if flags collied with something, add score and disable
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Try to get the ScoreManager component from the other object
            ScoreManager_E manager = other.GetComponent<ScoreManager_E>();

            if (manager != null)
            {
                manager.AddScore(amount);  // Add the score
                gameObject.SetActive(false);  // Deactivate the flag
            }
        }
    }
}
