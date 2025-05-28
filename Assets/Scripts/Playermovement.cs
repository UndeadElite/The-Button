using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraHead;

    public AudioSource walkAudio;
    public AudioClip walkClip;
    public float stepInterval = 0.4f;

    float xRotation = 0f;
    float stepTimer = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;

        // Footstep sound
        bool isMoving = move.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                walkAudio.pitch = Random.Range(0.9f, 1.1f);
                walkAudio.PlayOneShot(walkClip);
                stepTimer = 0f;
            }
        }
        else
        {
            walkAudio.Stop();
            stepTimer = stepInterval;
        }
    }
}
