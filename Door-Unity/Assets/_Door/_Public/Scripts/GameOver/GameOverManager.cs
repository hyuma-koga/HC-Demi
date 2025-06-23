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
        InputManager.Instance.SetInputEnabled(false);
        StartCoroutine(ShowResultAfterDelay());
    }

    private IEnumerator ShowResultAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f); // ŽžŠÔ’âŽ~’†‚Å‚à‘Ò‹@
        
        int currentScore = ScoreManager.Instance.GetCurrentScore();
        int lastScore = ScoreManager.Instance.LastScore;

        if (resultUI != null)
        {
            resultUI.SetActive(true);
        }

        resultManager.ShowResult(currentScore, lastScore);
        ScoreManager.Instance.SaveLastScore();
    }
}
