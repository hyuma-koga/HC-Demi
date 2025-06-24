using UnityEngine;

public enum GameState
{
    Title,
    WaitingForClick,
    Playing,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance {  get; private set; }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CurrentState = GameState.Title;
        Time.timeScale = 0f;
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Time.timeScale = (newState == GameState.Playing) ? 1f : 0f;
    }
}