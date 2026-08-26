using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera cam;
    public Player player;

    public float normalZoom = 5f;
    public float dashZoom = 10f;
    public float zoomSpeed = 10f;

    void Update()
    {
        if(player.isDashing)
        {
            cam.Lens.OrthographicSize = Mathf.Lerp(
            cam.Lens.OrthographicSize,
            dashZoom,
            zoomSpeed * Time.deltaTime
            );
        }
        else
        {
            cam.Lens.OrthographicSize = Mathf.Lerp(
            cam.Lens.OrthographicSize,
            normalZoom,
            zoomSpeed * Time.deltaTime
            );
        }
        
    }
}