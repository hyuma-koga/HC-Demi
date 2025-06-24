using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TitleUIManager : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject startPromptUI;
    public TMP_Text highScoreText;
    public Text lastScoreText;

    private void Start()
    {
        titleUI.SetActive(true);
        startPromptUI.SetActive(false);
        StartCoroutine(DelayScoreUpdate());
    }

    private void OnEnable()
    {
        StartCoroutine(DelayScoreUpdate());
    }

    private IEnumerator DelayScoreUpdate()
    {
        while (ScoreManager.Instance == null)
        {
            yield return null;
        }

        UpdateScoreTexts();
    }

    public void OnStartButtonClicked()
    {
        titleUI.SetActive(false);
        startPromptUI.SetActive(true);
        GameStateManager.Instance.SetState(GameState.WaitingForClick);
    }

    public void UpdateScoreTexts()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogWarning("ScoreManager.Instance is null.");
            return;
        }

        int high = ScoreManager.Instance.HighScore;
        int last = ScoreManager.Instance.LastScore;

        if (highScoreText != null)
        {
            highScoreText.text = $"{high}";
        }

        if (lastScoreText != null)
        {
            lastScoreText.text = $"{last}";
        }
    }
}