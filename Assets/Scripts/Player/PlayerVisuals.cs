using System;
using UnityEngine;

namespace Player 
{
    public class PlayerVisuals : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerInputReader _inputReader;
        
        private const string IS_RUNNING = "isRunning";

        private void Awake()
        {
           _animator = GetComponent<Animator>();
           _spriteRenderer = GetComponent<SpriteRenderer>();

           if (_inputReader == null)
           {
               _inputReader = GetComponentInParent<PlayerInputReader>();
           }
        }

        private void OnEnable()
        {
            _playerMovement.OnMovingStateChanged += HandleMoving;
            _inputReader.OnLookAtMouse += HandleFlipX;
        }

        private void OnDisable()
        {
            _playerMovement.OnMovingStateChanged -= HandleMoving;
            _inputReader.OnLookAtMouse -= HandleFlipX;
        }

        private void HandleMoving(bool isMoving)
        {
            _animator.SetBool(IS_RUNNING, isMoving);
        }

        private void HandleFlipX(Vector3 mouseWorldPos)
        {
            _spriteRenderer.flipX = mouseWorldPos.x < transform.position.x;
        }
    }
}
