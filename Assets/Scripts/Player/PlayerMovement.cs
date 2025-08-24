using System;
using UnityEngine;

namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<bool> OnMovingStateChanged;
        
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
                    OnMovingStateChanged?.Invoke(_isMoving);
                }
            }
        }

        private void Awake()
        {
            _rigidbody2D =  GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            var inputReader = GetComponent<PlayerInputReader>();
            inputReader.OnMove += SetMoveInput;
        }

        private void SetMoveInput(Vector2 direction)
        {
            _moveInput = direction;
        }

        private void FixedUpdate()
        {
            IsMoving = _moveInput != Vector2.zero;
            _rigidbody2D.linearVelocity = _moveInput.normalized * _speed;
        }
    }
}
