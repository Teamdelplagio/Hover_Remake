using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("play");
    }    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
