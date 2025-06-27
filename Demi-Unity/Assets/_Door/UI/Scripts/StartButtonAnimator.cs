using UnityEngine;

public class StartButtonAnimator : MonoBehaviour
{
    public float rotationAmplitude = 5f;    // ��]�̕��i�}�x�j
    public float scaleAmplitude = 0.05f;    // �g��k���̕��i1�}�l�j
    public float animationSpeed = 2f;       // �A�j���[�V�����̑���

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

        // �g��k��
        float scaleOffset = Mathf.Sin(t) * scaleAmplitude;
        transform.localScale = initialScale * (1f + scaleOffset);

        // ��]�iZ���ɂ����j
        float angle = Mathf.Sin(t) * rotationAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}