using UnityEngine;

public class StartPromptManager : MonoBehaviour
{
    public GameObject startPromptUI;
    public GameObject scoreUI;

    private void Update()
    {
        if (GameStateManager.Instance.CurrentState == GameState.WaitingForClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPromptUI.SetActive(false);
                scoreUI.SetActive(true);
                GameStateManager.Instance.SetState(GameState.Playing);
            }
        }
    }
}
