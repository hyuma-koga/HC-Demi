using UnityEngine;

public class PlayerBoundaryChecker : MonoBehaviour
{
    public float minY = -4.6f;
    public float maxY = 4.7f;
    public float bounceForce = 6f;
    public float dampingRate = 0.8f;
    public float minBounceForce = 1f;
    public float gameOverDelay = 0.1f;

    private Rigidbody2D rb;
    private bool hasTriggeredGameOver = false;
    private int bounceCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float y = transform.position.y;

        if (y < minY)
        {
            Bounce(Vector2.up);
        }
        else if (y > maxY)
        {
            Bounce(Vector2.down);
        }
    }

    private void Bounce(Vector2 direction)
    {
        float currentForce = bounceForce * Mathf.Pow(dampingRate, bounceCount);
        currentForce = Mathf.Max(currentForce, minBounceForce);

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // y���x���Z�b�g
        rb.AddForce(direction * currentForce, ForceMode2D.Impulse); // ? �����͂�K�p

        bounceCount++;

        if (!hasTriggeredGameOver)
        {
            hasTriggeredGameOver = true;
            Invoke(nameof(TriggerGameOver), gameOverDelay);
        }
    }

    public void ResetBoundaryCheck()
    {
        hasTriggeredGameOver = false;
        bounceCount = 0;
    }

    private void TriggerGameOver()
    {
        GameOverManager.Instance.TriggerGameOver("Hit top or bottom");
    }
}