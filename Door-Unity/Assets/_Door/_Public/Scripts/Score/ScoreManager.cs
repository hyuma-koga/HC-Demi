using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public TMP_Text text_Score;        //�ʏ�X�R�A
    public TMP_Text text_Multiplier;   //�{��

    [Header("Effect")]
    public PlayerEffectController playerEffectController;

    [Header("Visual")]
    public PlayerColorController playerColorController;

    public int LastScore { get; private set; } = 0;
    public int HighScore { get; private set; } = 0;

    private int currentScore = 0;
    private int currentMultiplier = 1;
    private Coroutine multiplierDisplayCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(bool isPerfect)
    {
        if (isPerfect)
        {
            currentMultiplier++;   //�����Ȃ�2�{
            currentScore += currentMultiplier;
            ShowMultiplierText();
            playerEffectController?.PlayEffect();
            playerColorController?.SetPerfectSprite();
        }
        else
        {
            currentMultiplier = 1;    //�U�ꂽ��{�����Z�b�g
            currentScore += 1;
            text_Multiplier?.gameObject.SetActive(false);
            playerEffectController?.StopEffect();
            playerColorController?.SetNormalSprite();
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

        if (multiplierDisplayCoroutine != null)
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
        playerEffectController?.StopEffect();
        playerColorController?.SetNormalSprite();
    }

    public void SaveLastScore()
    {
        LastScore = currentScore;

        if (currentScore > HighScore)
        {
            HighScore = currentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
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
