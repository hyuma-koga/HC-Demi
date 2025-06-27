using System.Collections;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public ResultManager resultManager;
    public GameObject resultUI;
    public AudioClip gameOverSound;

    private AudioSource audioSource;
    private bool hasTriggeredGameOver = false;

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

        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerGameOver(string reason)
    {
        if (hasTriggeredGameOver)
        {
            return;
        }

        hasTriggeredGameOver = true;

        InputManager.Instance.SetInputEnabled(false);

        if (gameOverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        StartCoroutine(ShowResultAfterDelay());
    }

    private IEnumerator ShowResultAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f); // ŽžŠÔ’âŽ~’†‚Å‚à‘Ò‹@
        
        int currentScore = ScoreManager.Instance.GetCurrentScore();
        int lastScore = ScoreManager.Instance.LastScore;

        resultManager.ShowResult(currentScore, lastScore);
        ScoreManager.Instance.SaveLastScore();
    }

    public void ResetGameOverTrigger()
    {
        hasTriggeredGameOver = false;
    }
}