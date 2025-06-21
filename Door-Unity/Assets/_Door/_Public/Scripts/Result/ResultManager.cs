using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text text_CurrentScore;
    public Text text_LastScore;

    public void ShowResult(int current, int last)
    {
        gameObject.SetActive(true);
        text_CurrentScore.text = $"{ current}";
        text_LastScore.text = $"{last}";
    }
}
