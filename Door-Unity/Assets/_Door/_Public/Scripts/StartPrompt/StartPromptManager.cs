using UnityEngine;

public class StartPromptManager : MonoBehaviour
{
    public GameObject startPromptUI;
    public GameObject scoreUI;

    [Header("Sound")]
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameStateManager.Instance.CurrentState == GameState.WaitingForClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (clickSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(clickSound);
                }

                startPromptUI.SetActive(false);
                scoreUI.SetActive(true);

                ScoreManager.Instance.ResetScore();
                GameStateManager.Instance.SetState(GameState.Playing);
                InputManager.Instance.SetInputEnabled(true);
            }
        }
    }
}