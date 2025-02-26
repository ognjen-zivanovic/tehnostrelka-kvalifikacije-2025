using UnityEngine;
using UnityEngine.InputSystem;

public class GetClicked : MonoBehaviour
{   
    void Update () {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            CastRay(mousePosition, true);
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            CastRay(mousePosition, false);
        }


        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            CastRay(touchPosition, true);
        }
        else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasReleasedThisFrame)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            CastRay(touchPosition, false);
        }
    }

    void CastRay(Vector2 clickPos, bool pressed) {
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitGameObject = hit.collider.gameObject;
            DoSomethingOnClick click = hitGameObject.GetComponent<DoSomethingOnClick>();
            if (click != null) {
                if (pressed) {
                    click.InvokePressEvent();
                }
                else {
                    click.InvokeReleaseEvent();
                }
            }
        }
    }

}
