using UnityEngine;
using UnityEngine.UI;

public class ScoreSpriteUI_E : MonoBehaviour
{
    [SerializeField] private Image[] flags;

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
