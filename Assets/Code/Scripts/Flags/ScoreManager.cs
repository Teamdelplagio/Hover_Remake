using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (score >= 6) 
        {
            //PlayAgain playAgain = new PlayAgain();
            //playAgain.gameObject.SetActive(true);
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
           Debug.Log(other.gameObject.name);
    }
}
