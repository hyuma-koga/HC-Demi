using UnityEngine;

public class StartButtonAnimator : MonoBehaviour
{
    public float rotationAmplitude = 5f;    // 回転の幅（±度）
    public float scaleAmplitude = 0.05f;    // 拡大縮小の幅（1±値）
    public float animationSpeed = 2f;       // アニメーションの速さ

    private Vector3 initialScale;
    private Quaternion initialRotation;

    private void Start()
    {
        initialScale = transform.localScale;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float t = Time.unscaledTime * animationSpeed;

        // 拡大縮小
        float scaleOffset = Mathf.Sin(t) * scaleAmplitude;
        transform.localScale = initialScale * (1f + scaleOffset);

        // 回転（Z軸にゆらゆら）
        float angle = Mathf.Sin(t) * rotationAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}