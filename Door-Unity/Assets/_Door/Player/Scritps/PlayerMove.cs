using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed_Move = 1f;
    public float speed_RotationRestore = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveForward()
    {
        //x�����������x�����Ɉێ��i�����O�Փ˒��͐��䂵�Ȃ��j
        Vector2 velocity = rb.linearVelocity;
        velocity.x = speed_Move;
        rb.linearVelocity = velocity;
    }

    private void FixedUpdate()
    {
        float currentZ = transform.rotation.eulerAngles.z;
        if(currentZ > 100f)
        {
            currentZ -= 360f;
        }

        float newZ = Mathf.Lerp(currentZ, 0f, Time.fixedDeltaTime * speed_RotationRestore);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }
}
