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
        //x�����������x�����Ɉێ��i�����O�Փ˒��͐��䂵�Ȃ��j
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveSpeed;
        rb.linearVelocity = velocity;
    }
}
