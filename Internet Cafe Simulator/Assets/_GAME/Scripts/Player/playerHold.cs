using UnityEngine;
using UnityEngine.InputSystem;

public class playerHold : MonoBehaviour
{
    private void Start()
    {
        inputManager.Instance.action.Player.Interact.performed += onInteractPressed;
    }

    void onInteractPressed(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {

        }
    }
}
