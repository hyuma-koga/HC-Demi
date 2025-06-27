using UnityEngine;
using System.Collections;

public class RingFadeOut : MonoBehaviour
{
    public float delayBeforeFade = 0.5f;
    public float fadeDuration = 1f;

    private SpriteRenderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void FadeAndDisable()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;
        
        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            foreach (var sr in renderers)
            {
                Color c = sr.color;
                c.a = alpha;
                sr.color = c;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        foreach (var sr in renderers)
        {
            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }

        Destroy(gameObject);
    }
}
