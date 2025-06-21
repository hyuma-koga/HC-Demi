using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public Transform[] backgrounds;
    public Transform player;
    public float backgroundWidth = 20f;

    private void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            //�v���C���[���w�i�̉E���𒴂�����A�w�i����ԉE�ɍĔz�u
            if(player.position.x - bg.position.x > backgroundWidth)
            {
                Vector3 newPos = bg.position;
                newPos.x += backgroundWidth * backgrounds.Length;
                bg.position = newPos;
            }
        }
    }
}
