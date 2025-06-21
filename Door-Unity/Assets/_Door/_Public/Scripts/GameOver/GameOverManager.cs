using System.Collections;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public ResultManager resultManager;
    public GameObject resultUI;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerGameOver(string reason)
    {
        Time.timeScale = 0f;
        ScoreManager.Instance.SaveLastScore(); // �X�R�A�ۑ�
        StartCoroutine(ShowResultAfterDelay());
    }

    private IEnumerator ShowResultAfterDelay()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f); // ���Ԓ�~���ł��ҋ@
        resultManager.ShowResult(
            ScoreManager.Instance.GetCurrentScore(),
            ScoreManager.Instance.LastScore
        );
    }
}
