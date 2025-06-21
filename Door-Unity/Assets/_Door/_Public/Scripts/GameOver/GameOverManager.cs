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
        ScoreManager.Instance.SaveLastScore(); // スコア保存
        StartCoroutine(ShowResultAfterDelay());
    }

    private IEnumerator ShowResultAfterDelay()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f); // 時間停止中でも待機
        resultManager.ShowResult(
            ScoreManager.Instance.GetCurrentScore(),
            ScoreManager.Instance.LastScore
        );
    }
}
