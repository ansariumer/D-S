using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class dashButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public DashController dashController;
    public GameObject joystickbg;
    public GameObject handle;

    public Player player;
    public Button btn;

    [SerializeField] private float stopDuration = 2f;
    private Coroutine stopRoutine;

    void Start()
    {
        btn = GetComponent<Button>();

        handle.SetActive(false);
        joystickbg.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!btn.interactable)
        {
            return;
        }

        joystickbg.SetActive(true);
        handle.SetActive(true);

        if (dashController != null)
        {
            dashController.OnDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!btn.interactable)
        {
            return;
        }

        if (player != null)
        {
            handle.SetActive(true);
            joystickbg.SetActive(true);

            if (dashController != null)
            {
                dashController.OnDrag(eventData);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!btn.interactable)
        {
            return;
        }

        handle.SetActive(false);
        joystickbg.SetActive(false);

        Vector2 dashDir = Vector2.zero;

        if (dashController != null)
        {
            // Save direction BEFORE resetting joystick
            dashDir = dashController.Direction;

            dashController.OnPointerUp(eventData);
        }

        if (player != null)
        {
            player.Dash(dashDir);
        }

        if (stopRoutine == null)
        {
            btn.interactable = false;
            stopRoutine = StartCoroutine(StopDash());
        }
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(stopDuration);

        btn.interactable = true;
        stopRoutine = null;
    }
}