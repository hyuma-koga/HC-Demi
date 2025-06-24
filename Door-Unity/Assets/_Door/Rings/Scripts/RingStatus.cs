using UnityEngine;

public class RingStatus : MonoBehaviour
{
    public bool touchhedEdge = false;

    public void MarkTouched()
    {
        touchhedEdge = true;
    }

    public bool IsPerfect()
    {
        return !touchhedEdge;
    }
}