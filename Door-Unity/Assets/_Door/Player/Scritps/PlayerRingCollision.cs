using UnityEngine;
using UnityEngine.XR;

public class PlayerRingCollision : MonoBehaviour
{
    public float force_bounce = 1.5f;
    public float force_torque = 0.2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            RingStatus ringStatus = collision.gameObject.GetComponentInParent<RingStatus>();
            
            if (ringStatus != null)
            {
                ringStatus.MarkTouched();
            }

            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = rb.worldCenterOfMass;
            Vector2 direction = (center - contactPoint).normalized;

            rb.AddForce(direction * force_bounce, ForceMode2D.Impulse);

            float torqueDirection = Mathf.Sign(Vector3.Cross(direction, Vector3.forward).z);
            rb.AddTorque(torqueDirection * force_torque, ForceMode2D.Impulse);
        }
    }
}