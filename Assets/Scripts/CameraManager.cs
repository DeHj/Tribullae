using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof (Camera))]
public class CameraManager : MonoBehaviour
{
    public float offsetX;
    public float offsetY;

    public float minSize;
    public float maxSize;
    public float zoomStep;

    public float speedRate;

    public GameObject toggledBody;
    private Camera _toggledCamera;

    private Vector3 CameraPosition
    {
        get => _toggledCamera.transform.position;
        set => _toggledCamera.transform.position = value;
    }

    private void Start()
    {
        _toggledCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (toggledBody is not null)
        {
            CameraPosition += (toggledBody.transform.position + new Vector3(offsetX, offsetY, CameraPosition.z) - CameraPosition) * speedRate;
        }

        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Input.GetButtonUp("Camera Zoom"))
        {
            var input = Input.GetAxis("Camera Zoom");
            if (input > math.EPSILON)
            {
                ZoomIn();
            }
            else if (input < -math.EPSILON)
            {
                ZoomOut();
            }
        }
    }

    public void ZoomIn()
    {
        if (_toggledCamera.orthographicSize > minSize)
        {
            _toggledCamera.orthographicSize /= zoomStep;
        }
    }

    public void ZoomOut()
    {
        if (_toggledCamera.orthographicSize < maxSize)
        {
            _toggledCamera.orthographicSize *= zoomStep;
        }
    }
}