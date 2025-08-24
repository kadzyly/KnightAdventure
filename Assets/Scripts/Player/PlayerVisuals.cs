using System;
using UnityEngine;

namespace Player 
{
    public class PlayerVisuals : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private PlayerMovement _playerMovement;
        private bool _currentRunningState = false;
        
        private const string IS_RUNNING = "isRunning";

        private void Awake()
        {
           _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            bool isRun = _playerMovement.IsMoving;

            if (_currentRunningState != isRun)
            {
                _currentRunningState = isRun;
                _animator.SetBool(IS_RUNNING, isRun);
            }
        }
    }
}
