using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public Transform[] backgrounds;
    public Transform player;
    public float backgroundWidth = 5.63f;

    private Vector3[] initialPositions;

    private void Start()
    {
        initialPositions = new Vector3[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            initialPositions[i] = backgrounds[i].position;
        }
    }

    private void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            //ƒvƒŒƒCƒ„[‚ª”wŒi‚Ì‰E‘¤‚ð’´‚¦‚½‚çA”wŒi‚ðˆê”Ô‰E‚ÉÄ”z’u
            if(player.position.x - bg.position.x > backgroundWidth)
            {
                Vector3 newPos = bg.position;
                newPos.x += backgroundWidth * backgrounds.Length;
                bg.position = newPos;
            }
        }
    }

    public void ResetBackgrounds()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = initialPositions[i];
        }
    }
}
