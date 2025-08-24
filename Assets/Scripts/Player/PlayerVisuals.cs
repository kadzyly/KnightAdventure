using System;
using UnityEngine;

namespace Player 
{
    public class PlayerVisuals : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private PlayerMovement _playerMovement;
        
        private const string IS_RUNNING = "isRunning";

        private void Awake()
        {
           _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _playerMovement.OnMovingStateChanged += HandleMoving;
        }

        private void OnDisable()
        {
            _playerMovement.OnMovingStateChanged -= HandleMoving;
        }

        void HandleMoving(bool isMoving)
        {
            _animator.SetBool(IS_RUNNING, isMoving);
        }
    }
}
