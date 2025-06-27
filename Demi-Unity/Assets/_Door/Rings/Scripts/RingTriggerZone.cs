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

        //プレイヤーが下からくぐったらゲームオーバー
        if (other.transform.position.y < transform.position.y)
        {
            GameOverManager.Instance.TriggerGameOver("リングを下からくぐった");
            return;
        }

        //スコア処理
        RingStatus ringStatus = GetComponentInParent<RingStatus>();
        bool isPerfect = ringStatus != null && ringStatus.IsPerfect();
        ScoreManager.Instance.AddScore(isPerfect);

        //フェードアウト処理
        RingFadeOut fadeOut = GetComponentInParent<RingFadeOut>();

        if (fadeOut != null)
        {
            fadeOut.FadeAndDisable();
        }
    }
}