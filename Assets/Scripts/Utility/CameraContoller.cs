using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Target; // The object the camera will follow
    [SerializeField] private float followSpeed = 15f; // Speed of camera following
    private Vector3 offset; // Initial offset between camera and target

    void Start()
    {
        // Calculate initial offset
        offset = transform.position - Target.position;
    }

    void Update()
    {
        // Handle camera following
        FollowTarget();
    }

    void FollowTarget()
    {
        // Calculate the desired position the camera should be at
        Vector3 desiredPosition = Target.position + offset;
        // Interpolate towards the target position smoothly
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }





}
