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

        //�v���C���[�������炭��������Q�[���I�[�o�[
        if (other.transform.position.y < transform.position.y)
        {
            GameOverManager.Instance.TriggerGameOver("�����O�������炭������");
            return;
        }

        //�X�R�A����
        RingStatus ringStatus = GetComponentInParent<RingStatus>();
        bool isPerfect = ringStatus != null && ringStatus.IsPerfect();
        ScoreManager.Instance.AddScore(isPerfect);

        //�t�F�[�h�A�E�g����
        RingFadeOut fadeOut = GetComponentInParent<RingFadeOut>();

        if (fadeOut != null)
        {
            fadeOut.FadeAndDisable();
        }
    }
}