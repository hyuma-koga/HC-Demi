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

    [Header("Player")]
    public GameObject player;

    [Header("Background")]
    public BackgroundLooper backgroundLooper;

    [Header("RingSpawner")]
    public RingSpawner ringSpawner;

    private Vector3 initialPlayerPosition = new Vector3(-1.5f, 0f, 0f);

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

        if (player != null)
        {
            player.transform.position = initialPlayerPosition;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            PlayerBoundaryChecker checker = player.GetComponent<PlayerBoundaryChecker>();
            if (checker != null)
            {
                checker.ResetBoundaryCheck();
            }

            CameraFollow cameraFollow = FindAnyObjectByType<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.SnapToTarget();
            }
        }

        if (backgroundLooper != null)
        {
            backgroundLooper.ResetBackgrounds();
        }

        if (ringSpawner != null)
        {
            ringSpawner.ResetSpawner();
        }

        Object.FindFirstObjectByType<TitleUIManager>()?.UpdateScoreTexts();
        GameStateManager.Instance.SetState(GameState.Title);
    }
}
