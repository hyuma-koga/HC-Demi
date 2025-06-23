using UnityEngine;

public class RingEdge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RingStatus ringStatus = GetComponentInParent<RingStatus>();
            if (ringStatus != null)
            {
                ringStatus.MarkTouched();
            }
        }
    }
}
