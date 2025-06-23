using System.Collections;
using UnityEngine;

public class InputBlocker : MonoBehaviour
{
    public static bool IsBlocked { get; private set; } = false;

    private static InputBlocker Instance;

    private void Awake()
    {
        // Singleton\¬
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// w’è•b”‚¾‚¯“ü—Í‚ğ–³Œø‰»‚·‚é
    /// </summary>
    public static void BlockInput(float duration)
    {
        Debug.Log($"[InputBlocker] BlockInput called for {duration} seconds");

        if (Instance != null)
        {
            Instance.StartCoroutine(Instance.UnblockAfterSeconds(duration));    
        }

        IsBlocked = true;
    }

    private IEnumerator UnblockAfterSeconds(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        IsBlocked = false;
        Debug.Log("[InputBlocker] Input unblocked.");
    }
}