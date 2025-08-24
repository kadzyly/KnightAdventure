using UnityEngine;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveInput;

        [SerializeField] private float _speed = 5f;

        public bool IsMoving { get; private set; }

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
            IsMoving = _moveInput != Vector2.zero;
            _rigidbody2D.linearVelocity = _moveInput.normalized * _speed;
        }
    }
}
