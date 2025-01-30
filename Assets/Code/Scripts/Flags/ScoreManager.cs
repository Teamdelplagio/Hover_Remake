using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreSpriteUi spriteUI;
    [SerializeField] private int score;

    //stampa il punteggio a schermo
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
