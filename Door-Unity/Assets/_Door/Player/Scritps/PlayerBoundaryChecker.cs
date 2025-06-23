using UnityEngine;

public class PlayerBoundaryChecker : MonoBehaviour
{
    public float minY = -4.6f;
    public float maxY = 4.7f;

    private bool hasTriggeredGameOver = false;

    private void Update()
    {
        float y = transform.position.y;

        if (!hasTriggeredGameOver && (y < minY || y > maxY))
        {
            hasTriggeredGameOver = true;
            Debug.Log("Y�������𒴂����̂ŃQ�[���I�[�o�[");
            GameOverManager.Instance.TriggerGameOver("Y out of bounds");
        }
    }

    // �Q�[���ăX�^�[�g���Ƀ��Z�b�g�����悤�ɂ���
    public void ResetBoundaryCheck()
    {
        hasTriggeredGameOver = false;
    }
}