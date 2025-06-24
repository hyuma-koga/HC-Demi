using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float force_Jump = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleJumpInput()
    {
        if (!InputManager.Instance.IsInputEnabled())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, force_Jump);
        }
    }
}