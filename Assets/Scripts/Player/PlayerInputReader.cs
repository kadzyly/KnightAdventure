using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Player 
{
    public class PlayerInputReader : MonoBehaviour
    {
        private InputSystem_Actions _inputActions;
        public event Action<Vector2> OnMove;
        public event Action<Vector3> OnLookAtMouse;

        private void Awake()
        {
            _inputActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();
            _inputActions.Player.Move.performed += HandleMove;
            _inputActions.Player.Move.canceled += HandleMove;
            _inputActions.Player.Look.performed += HandleLookAtMouse;
        }

        private void OnDisable()
        {
            _inputActions.Player.Move.performed -= HandleMove;
            _inputActions.Player.Move.canceled -= HandleMove;
            _inputActions.Player.Look.performed -= HandleLookAtMouse;
            _inputActions.Player.Disable();
        }

        private void HandleMove(InputAction.CallbackContext ctx)
        {
            Vector2 move = ctx.ReadValue<Vector2>();
            OnMove?.Invoke(move);
        }

        private void HandleLookAtMouse(InputAction.CallbackContext ctx)
        {
            if (!Camera.main) return;

            var screenPos = (Vector3)ctx.ReadValue<Vector2>();
            screenPos.z = Mathf.Abs(Camera.main.transform.position.z);

            var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;

            OnLookAtMouse?.Invoke(worldPos);
        }
    }
}
