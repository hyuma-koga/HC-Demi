using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(1.5f, 0f, -10f);

    private void LateUpdate()
    {
        if(target == null)
        {
            return;
        }

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
