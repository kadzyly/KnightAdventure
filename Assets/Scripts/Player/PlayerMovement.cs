using System;
using UnityEngine;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<bool> OnMoovingStateChanged;
        
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveInput;

        [SerializeField] private float _speed = 5f;

        private bool _isMoving;

        public bool IsMoving
        {
            get => _isMoving;
            private set
            {
                if (value != _isMoving)
                {
                    _isMoving = value;
                    OnMoovingStateChanged?.Invoke(_isMoving);
                }
            }
        }

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
