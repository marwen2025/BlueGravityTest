using UnityEngine;
using UnityEngine.InputSystem;

public class DisableClicksOnUI : MonoBehaviour
{
    public InputActionReference clickActionReference; // Use InputActionReference

    private InputAction clickAction;

    void OnEnable()
    {
        // Get the InputAction from the reference
        clickAction = clickActionReference.action;
        clickAction.performed += OnClickPerformed;
        clickAction.Enable();
    }

    void OnDisable()
    {
        clickAction.performed -= OnClickPerformed;
        clickAction.Disable();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        // Your logic here
    }
}
