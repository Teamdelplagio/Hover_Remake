using UnityEngine;
using UnityEngine.Audio;

public class FlagScore : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    public AudioSource audioSource;
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    //se le bandiere collidono con qualcos'altro, aumenta il punteggio e si disattivano
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out ScoreManager manager))
        {
            manager.AddScore(amount);
            audioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
