using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private Transform checkGroundPoint;
        [SerializeField] private float checkGroundRadius;

        private Vector3 _moveDir;
        private float _velocity;
        
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this._inputService = inputService;
        }

        private void Update()
        {
            var playerMoveInput = _inputService.GetMoveDirection();
            
            float horizontalInput = playerMoveInput.x;
            float verticalInput = playerMoveInput.y;

            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            _moveDir = moveDirection;
            
            if (IsGround())
            {
                _velocity = -2;
            }
            
            Move(_moveDir);
            DoGravity();
        }
        private void Move(Vector3 dir)
        {
            characterController.Move(dir * speed * Time.deltaTime);
        }

        private void DoGravity()
        {
            _velocity += gravity * Time.deltaTime;
            Move(Vector3.up * _velocity);
        }

        private bool IsGround()
        {
            bool result = Physics.CheckSphere(checkGroundPoint.position, checkGroundRadius, groundMask);
            return result;
        }
    }
}
