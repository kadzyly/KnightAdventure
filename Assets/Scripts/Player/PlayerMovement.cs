using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;
    [SerializeField] private float _speed = 5f;

    void Awake()
    {
        _rigidbody2D =  GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        var inputReader = GetComponent<PlayerInputReader>();
        inputReader.OnMove += SetMoveInput;
    }

    void SetMoveInput(Vector2 direction)
    {
        _moveInput = direction;
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _moveInput.normalized * _speed;
    }
}
