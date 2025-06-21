using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public TMP_Text text_Score;        //í èÌÉXÉRÉA
    public TMP_Text text_Multiplier;   //î{ó¶

    private int currentScore = 0;
    private int currentMultiplier = 1;

    private Coroutine multiplierDisplayCoroutine;

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
    }

    public void AddScore(bool isPerfect)
    {
        if (isPerfect)
        {
            currentMultiplier++;   //äÆ‡¯Ç»ÇÁ2î{
            int addedScore = 1 * currentMultiplier;
            currentScore += addedScore;

            ShowMultiplierText();
        }
        else
        {
            currentMultiplier = 1;    //êUÇÍÇΩÇÁî{ó¶ÉäÉZÉbÉg
            currentScore += 1;

            text_Multiplier?.gameObject.SetActive(false);
        }

        UpdateUI();
    }

    private void ShowMultiplierText()
    {
        if (text_Multiplier == null)
        {
            return;
        }

        text_Multiplier.text = currentMultiplier.ToString();
        text_Multiplier.gameObject.SetActive(true);

        if(multiplierDisplayCoroutine != null)
        {
            StopCoroutine(multiplierDisplayCoroutine);
        }

        multiplierDisplayCoroutine = StartCoroutine(HideMultiplierAfterDelay());
    }

    private IEnumerator HideMultiplierAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        text_Multiplier.gameObject.SetActive(false);
        multiplierDisplayCoroutine = null;
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentMultiplier = 1;
        UpdateUI();
        text_Multiplier?.gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        if (text_Score != null)
        {
            text_Score.text = currentScore.ToString();
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
