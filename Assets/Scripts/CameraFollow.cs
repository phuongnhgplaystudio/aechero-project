using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    public Transform target;

    [Header("Settings")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform topLimitPosition;
    [SerializeField] private Transform bottomLimitPosition;
    [SerializeField] [Range(1, 10)] private float smoothFactor;

    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition,
                                                smoothFactor * Time.deltaTime);
        if (smoothPosition.y < bottomLimitPosition.position.y)
        {
            smoothPosition.y = bottomLimitPosition.position.y;
        }
        if (smoothPosition.y > topLimitPosition.position.y)
        {
            smoothPosition.y = topLimitPosition.position.y;
        }

        smoothPosition.x = 0;
        smoothPosition.z = -10;
        transform.position = smoothPosition;
    }
}
