using UnityEngine;

public class PlayerEffectController : MonoBehaviour
{
    [Header("Perfect通過エフェクト")]
    public ParticleSystem perfectEffect;

    public void PlayEffect()
    {
        if (perfectEffect != null && !perfectEffect.isPlaying)
        {
            perfectEffect.Play();
        }
    }

    public void StopEffect()
    {
        if (perfectEffect != null && perfectEffect.isPlaying)
        {
            perfectEffect.Stop();
        }
    }
}