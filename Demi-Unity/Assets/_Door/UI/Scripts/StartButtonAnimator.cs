using UnityEngine;

public class StartButtonAnimator : MonoBehaviour
{
    public float rotationAmplitude = 5f;    // ñ]Ìi}xj
    public float scaleAmplitude = 0.05f;    // gåk¬Ìi1}lj
    public float animationSpeed = 2f;       // Aj[VÌ¬³

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

        // gåk¬
        float scaleOffset = Mathf.Sin(t) * scaleAmplitude;
        transform.localScale = initialScale * (1f + scaleOffset);

        // ñ]iZ²Éäçäçj
        float angle = Mathf.Sin(t) * rotationAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}