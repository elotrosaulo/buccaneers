using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryMenuUI;
    public RobotAnimVictory Robot;

    private void Start()
    {
        GameManager.OnVictory -= SetVictory;
        GameManager.OnVictory += SetVictory;
    }

    private void SetVictory()
    {
        Time.timeScale = 0f;
        victoryMenuUI.SetActive(true);
        Robot.Func_PlayUIAnim();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        victoryMenuUI.SetActive(false);
        GameManager.instance.RestartFromMenu();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Load Menu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
