using UnityEngine;
using UnityEngine.XR;

public class PlayerRingCollision : MonoBehaviour
{
    public float bounceForce = 3f;
    public float torqueForce = 20f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = rb.worldCenterOfMass;
            Vector2 direction = (center - contactPoint).normalized;

            rb.AddForce(direction * bounceForce, ForceMode2D.Impulse);

            float torqueDirection = Mathf.Sign(Vector3.Cross(direction, Vector3.forward).z);
            rb.AddTorque(torqueDirection * torqueForce, ForceMode2D.Impulse);
        }
    }
}
