using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float boostAmount = 5f;   // Amount added to player' speed
    public float boostDuration = 3f; // Duration of the speed boost



    //If it collides with the tag "Player", it adds the boost
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collisione");
            Movement player = other.GetComponent<Movement>();
            if (player != null)
            {
                player.ApplySpeedBoost(boostAmount, boostDuration);
            }
        }
    }
}
