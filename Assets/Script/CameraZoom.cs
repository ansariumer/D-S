/*using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera cam;
    public float normalZoom = 5f;
    public float dashZoom = 15f;
    public float zoomSpeed = 5f;

    //public Button myBtn;
    //private bool Btnpressed;

    public void Click()
    {
        Debug.Log("Clicked!!");
        cam.Lens.OrthographicSize = Mathf.Lerp(normalZoom, dashZoom, zoomSpeed * Time.deltaTime);
    }
}
*/

using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera cam;

    public float normalZoom = 5f;
    public float dashZoom = 10f;
    public float zoomSpeed = 10f;

    private float targetZoom;

    void Start()
    {
        targetZoom = normalZoom;
    }

    void Update()
    {
        cam.Lens.OrthographicSize = Mathf.Lerp(
            cam.Lens.OrthographicSize,
            targetZoom,
            zoomSpeed * Time.deltaTime
        );
    }

    public void Click()
    {
        Debug.Log("Clicked!!");

        if (targetZoom == normalZoom)
            targetZoom = dashZoom;
        else
            targetZoom = normalZoom;
    }
}
