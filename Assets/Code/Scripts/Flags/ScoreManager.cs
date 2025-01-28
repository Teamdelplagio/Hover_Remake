using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreSpriteUi spriteUI;
    [SerializeField] private ScoreUI ui;
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
