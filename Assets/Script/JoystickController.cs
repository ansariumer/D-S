using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform handle;
    public RectTransform background;

    public Vector2 Direction { get; private set; }

    private float radius;

    void Start()
    {
        radius = background.sizeDelta.x * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 center = RectTransformUtility.WorldToScreenPoint(
            eventData.pressEventCamera,
            background.position
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