using Behaviors;
using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public float secondsBeforeRestart;
    public PauseMenu pauseMenu;
    public VictoryMenu victoryMenu;
    public DialogueManager dialogueManager;

    public static Action OnRestart;
    public static Action OnVictory;
    public static Action OnExit;
    public static GameManager instance
    {
        get; private set; 
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.OnHealthAtZero -= GameOver;
        HealthSystem.OnHealthAtZero += GameOver;
    }

    public void GameOver() 
    {
        Debug.Log("Game over!");
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(secondsBeforeRestart);
        OnRestart?.Invoke();
    }

    public void Victory() 
    {
        OnVictory?.Invoke();
        Debug.Log("Game won!");
    }

    public void ExitGame()
    {
        OnExit?.Invoke();
        Debug.Log("Game won!");
    }

    public bool uiOnScreen()
    {
        return dialogueManager.isOnScreen || pauseMenu.isPaused;
    }
}
