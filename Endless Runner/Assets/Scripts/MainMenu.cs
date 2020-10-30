using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Runner");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You Left");
    }
}
