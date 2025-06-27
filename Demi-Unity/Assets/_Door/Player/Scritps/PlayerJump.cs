using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public AudioClip jumpSound;
    public float force_Jump = 3f;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void HandleJumpInput()
    {
        if (GameStateManager.Instance.CurrentState != GameState.Playing)
        {
            return;
        }

        if (!InputManager.Instance.IsInputEnabled())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, force_Jump);
        
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }
}