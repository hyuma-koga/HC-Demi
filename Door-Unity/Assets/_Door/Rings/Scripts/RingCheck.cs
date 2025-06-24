using UnityEngine;

public class RingCheck : MonoBehaviour
{
    public float triggerXOffset = 1.0f;
    public Transform player;

    private bool hasTriggeredGameOver = false;
    private RingStatus ringStatus;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        ringStatus = GetComponent<RingStatus>();
    }

    private void Update()
    {
        if (player == null || hasTriggeredGameOver)
            return;

        if (player.position.x > transform.position.x + triggerXOffset)
        {
            hasTriggeredGameOver = true;

            // �����O�ɐG��ĂȂ�������Q�[���I�[�o�[
            if (ringStatus == null || !ringStatus.touchhedEdge)
            {
                GameOverManager.Instance.TriggerGameOver("�����O�𖳎����Đi��");
            }
        }
    }
}