using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text ScoreText;
    public Image backgroundImg;
    private bool isShowned = false;
    private float transition = 0;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isShowned)
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        ScoreText.text = ((int)score).ToString();
        isShowned = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You Left");
    }
}
