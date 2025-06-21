using UnityEngine;

public class RingTriggerZone : MonoBehaviour
{
    private bool alreadyPassed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (alreadyPassed)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        alreadyPassed = true;

        if (other.transform.position.y < transform.position.y)
        {
            GameOverManager.Instance.TriggerGameOver("�����O�������炭������");
            return;
        }

        RingStatus ringStatus = GetComponentInParent<RingStatus>();
        bool isPerfect = ringStatus != null && ringStatus.IsPerfect();
        ScoreManager.Instance.AddScore(isPerfect);
    }
}
