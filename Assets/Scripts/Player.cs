using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction MoveAction;
    [SerializeField] float _speed = 5f;

    private bool _isMovementEnabled = true;

    private void OnEnable() => MoveAction.Enable();
    private void OnDisable() => MoveAction.Disable();

    void FixedUpdate()
    {
        if (!_isMovementEnabled) return;
        
        Vector2 movement = MoveAction.ReadValue<Vector2>();
        float frameSpeed = _speed * Time.deltaTime;
        transform.Translate(movement * frameSpeed);
    }
    
    public void EnableMovement() => _isMovementEnabled = true;
    public void DisableMovement() => _isMovementEnabled = false;
}
