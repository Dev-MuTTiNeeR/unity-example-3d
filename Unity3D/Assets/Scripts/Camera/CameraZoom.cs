using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCam;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 4f;
    [SerializeField] private float maxZoom = 15f;
    private CinemachinePositionComposer composer;

    private void Start()
    {
        if (virtualCam != null)
        {
            composer = virtualCam.GetComponent<CinemachinePositionComposer>();
        }
    }

    private void Update()
    {
        if (composer == null) return;

        float scroll = Input.mouseScrollDelta.y;
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float newDistance = Mathf.Clamp(composer.CameraDistance - scroll * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            composer.CameraDistance = newDistance;
        }
    }
}