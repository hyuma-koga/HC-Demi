using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text text_CurrentScore;
    public Text text_LastScore;

    [Header("UI References")]
    public GameObject resultUI;
    public GameObject titleUI;
    public GameObject scoreUI;
    public GameObject startPromptUI;

    public void ShowResult(int current, int last)
    {
        gameObject.SetActive(true);
        text_CurrentScore.text = $"{ current}";
        text_LastScore.text = $"{last}";
    }

    public void ReturnToTitle()
    {
        resultUI.SetActive(false);
        scoreUI.SetActive(false);
        startPromptUI.SetActive(false);
        titleUI.SetActive(true);

        ScoreManager.Instance.ResetScore();

        GameStateManager.Instance.SetState(GameState.Title);
    }
}
