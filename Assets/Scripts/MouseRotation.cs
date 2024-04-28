using UnityEngine;
using Cinemachine;

public class FreeLookCameraController : MonoBehaviour
{
    public float rotationSpeed = 1f; // Speed of camera rotation
    public CinemachineFreeLook freeLookCamera; // Reference to the FreeLook camera

    void Update()
    {
        if (freeLookCamera != null)
        {
            // Rotate the camera horizontally based on input
            float horizontalInput = Input.GetAxis("Horizontal");
            freeLookCamera.m_XAxis.m_InputAxisValue = horizontalInput * rotationSpeed;

            // Rotate the camera vertically based on input
            float verticalInput = Input.GetAxis("Vertical");
            freeLookCamera.m_YAxis.m_InputAxisValue = verticalInput * rotationSpeed;
        }
    }
}
