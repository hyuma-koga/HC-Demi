using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleUIManager : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject startPromptUI;
    public TMP_Text currentScoreText;
    public Text lastScoreText;

    private void Start()
    {
        UpdateScoreTexts();
        titleUI.SetActive(true);
        startPromptUI.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        titleUI.SetActive(false);
        startPromptUI.SetActive(true);
        GameStateManager.Instance.SetState(GameState.WaitingForClick);
    }

    private void UpdateScoreTexts()
    {
        int current = ScoreManager.Instance.GetCurrentScore();
        int last = ScoreManager.Instance.LastScore;

        if (currentScoreText != null)
        {
            currentScoreText.text = $"{current}";
        }

        if (lastScoreText != null)
        {
            lastScoreText.text = $"{last}";
        }
    }
}
