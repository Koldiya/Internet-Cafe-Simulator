using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    public static inputManager Instance { get; private set; }

    InputSystem_Actions action;

    private void Awake()
    {
        Instance = this;

        action = new InputSystem_Actions();
        action.Player.Enable();

        action.Player.Interact.performed += GetGetInteractObj;
    }

    private void GetGetInteractObj(InputAction.CallbackContext context)
    {
         
    }

    public Vector2 getMovementInput()
    {
        return action.Player.Move.ReadValue<Vector2>();
    }
}
