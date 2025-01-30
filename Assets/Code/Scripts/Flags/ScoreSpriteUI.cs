using UnityEngine;
using UnityEngine.UI;

public class ScoreSpriteUi : MonoBehaviour
{
    [SerializeField] private Image[] flags;
    
    //gestisce il punteggio
    private void Start()
    {
        foreach (var flag in flags)
        {
            flag.gameObject.SetActive(false);
        }
    }

    public void UpdateFlags(int amount)
    {
        flags[amount - 1].gameObject.SetActive(true);
    }

}
