using UnityEngine;

public class PlayerColorController : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public Sprite normalSprite;
    public Sprite perfectSprite;
    public Vector3 normalScale = Vector3.one;

    public void SetPerfectSprite()
    {
        if (playerRenderer != null && perfectSprite != null)
        {
            playerRenderer.sprite = perfectSprite;
            transform.localScale = normalScale;
        }
    }

    public void SetNormalSprite()
    {
        if (playerRenderer != null && normalSprite != null)
        {
            playerRenderer.sprite = normalSprite;
            transform.localScale = normalScale;
        }
    }
}