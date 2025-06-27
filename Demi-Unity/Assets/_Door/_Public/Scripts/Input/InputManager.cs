using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private bool inputEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInputEnabled(bool enabled)
    {
        inputEnabled = enabled;
    }

    public bool IsInputEnabled()
    {
        return inputEnabled;
    }
}