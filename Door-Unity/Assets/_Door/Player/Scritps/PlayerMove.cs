using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveForward()
    {
        //x方向だけ速度を一定に維持（リング衝突中は制御しない）
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveSpeed;
        rb.linearVelocity = velocity;
    }
}
