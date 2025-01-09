using UnityEngine;

public class NewCameraMovement : MonoBehaviour
{
    public GameObject target; // The object the camera will follow
    public float smoothSpeed = 0.2f; // Adjust for more/less smoothing
    public float velocityPredictionFactor = 0.4f; // Predict target's future position
    public float minZoom = 6f; // Minimum zoom (orthographic size)
    public float maxZoom = 8f; // Maximum zoom (orthographic size)
    public float zoomSpeed = 1f; // Speed of zooming in/out

    private Camera MainCamera;
    private Vector3 offset; // Offset from the target position
    private Vector3 velocity = Vector3.zero; // Velocity used by SmoothDamp

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera = GetComponent<Camera>(); // Get the Camera component attached to this GameObject
        offset = transform.position - target.transform.position;
    }

    void FixedUpdate()
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector3 desiredPosition = new Vector3(
                target.transform.position.x + ((rb.linearVelocity.x / 6) * velocityPredictionFactor),
                target.transform.position.y + 3 + ((rb.linearVelocity.y / 6) * velocityPredictionFactor),
                -10
            );

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

            float playerSpeed = Mathf.Abs(rb.linearVelocity.x); // Absolute horizontal velocity
            float targetZoom = Mathf.Lerp(minZoom, maxZoom, playerSpeed / 10f); // Map speed to zoom level

            MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }
}
