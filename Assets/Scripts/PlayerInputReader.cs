using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputReader : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    public event Action<Vector2> OnMove;

    void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _inputActions.Player.Enable();
        _inputActions.Player.Move.performed += HandleMove;
        _inputActions.Player.Move.canceled += HandleMove;
    }

    void OnDisable()
    {
        _inputActions.Player.Move.performed -= HandleMove;
        _inputActions.Player.Move.canceled -= HandleMove;
        _inputActions.Player.Disable();
    }

    void HandleMove(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        OnMove?.Invoke(move);
    }
}
