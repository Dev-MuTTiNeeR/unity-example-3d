using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 4f;
    [SerializeField] private float maxZoom = 15f;

    private Cinemachine3rdPersonFollow thirdPersonFollow;

    private void Start()
    {
        if (virtualCam != null)
        {
            thirdPersonFollow = virtualCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        }
    }

    private void Update()
    {
        if (thirdPersonFollow == null) return;

        float scrollInput = Input.mouseScrollDelta.y;

        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            float currentDistance = thirdPersonFollow.CameraDistance;
            float newDistance = Mathf.Clamp(currentDistance - scrollInput * zoomSpeed, minZoom, maxZoom);
            thirdPersonFollow.CameraDistance = newDistance;
        }
    }
}