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
            Debug.Log("Y軸制限を超えたのでゲームオーバー");
            GameOverManager.Instance.TriggerGameOver("Y out of bounds");
        }
    }

    // ゲーム再スタート時にリセットされるようにする
    public void ResetBoundaryCheck()
    {
        hasTriggeredGameOver = false;
    }
}