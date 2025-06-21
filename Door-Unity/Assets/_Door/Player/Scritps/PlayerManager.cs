using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMove move;
    private PlayerJump jump;
    private PlayerRingCollision ringCollision;

    private void Awake()
    {
        move = GetComponent<PlayerMove>();
        jump = GetComponent<PlayerJump>();
        ringCollision = GetComponent<PlayerRingCollision>();
    }

    private void Update()
    {
        jump.HandleJumpInput();
    }

    private void FixedUpdate()
    {
        move.MoveForward();
    }
}
