using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleJumpInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
