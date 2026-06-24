using UnityEngine;
using UnityEngine.EventSystems;

public class DashController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform joystickBackground;
    public RectTransform handle;

    public Vector2 Direction { get; private set; }

    private float radius;

    void Start()
    {
        radius = joystickBackground.sizeDelta.x * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 center = RectTransformUtility.WorldToScreenPoint(
            eventData.pressEventCamera,
            joystickBackground.position
        );

        Vector2 dir = eventData.position - center;

        Direction = Vector2.ClampMagnitude(dir / radius, 1f);

        handle.anchoredPosition = Direction * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
/*using UnityEngine;
using UnityEngine.EventSystems;

public class DashController : MonoBehaviour
{
    public RectTransform joystickBackground;
    public RectTransform handle;

    public Vector2 Direction { get; private set; }

    private float radius;

    void Start()
    {
        radius = joystickBackground.sizeDelta.x * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;

        Vector2 center = RectTransformUtility.WorldToScreenPoint(
            eventData.pressEventCamera,
            joystickBackground.position
        );

        Vector2 dir = pos - center;

        Direction = Vector2.ClampMagnitude(dir / radius, 1f);

        handle.anchoredPosition = Direction * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}*/
