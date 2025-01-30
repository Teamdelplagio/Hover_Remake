using UnityEngine;

public class ScoreManager_E : MonoBehaviour
{
    [SerializeField] private ScoreSpriteUi spriteUI;
    [SerializeField] private int score;

    public void AddScore(int count)
    {
        score += count;
        spriteUI.UpdateFlags(score);
        //ui.UpdateText(score);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
