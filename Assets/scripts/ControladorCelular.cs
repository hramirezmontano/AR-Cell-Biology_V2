using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ControladorCelular : MonoBehaviour
{
    private RectTransform rectTransform;

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        var touches = Touch.activeTouches;

        // 1 Dedo: Mover la célula
        if (touches.Count == 1)
        {
            var touch = touches[0];
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                rectTransform.anchoredPosition += touch.delta;
            }
        }

        // 2 Dedos: Pinch to Zoom (Escalar)
        if (touches.Count == 2)
        {
            var t0 = touches[0];
            var t1 = touches[1];

            Vector2 t0Prev = t0.screenPosition - t0.delta;
            Vector2 t1Prev = t1.screenPosition - t1.delta;

            float prevMagnitude = (t0Prev - t1Prev).magnitude;
            float currentMagnitude = (t0.screenPosition - t1.screenPosition).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Vector3 newScale = rectTransform.localScale + Vector3.one * (difference * 0.003f);

            // Límites de tamaño
            newScale.x = Mathf.Clamp(newScale.x, 0.4f, 2.5f);
            newScale.y = Mathf.Clamp(newScale.y, 0.4f, 2.5f);
            newScale.z = 1f;

            rectTransform.localScale = newScale;
        }
    }
}