using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    public static inputManager Instance { get; private set; }

    public InputSystem_Actions action;

    private void Awake()
    {
        Instance = this;

        action = new InputSystem_Actions();
        action.Player.Enable();
    }

    public Vector2 getMovementInput()
    {
        return action.Player.Move.ReadValue<Vector2>();
    }
}
