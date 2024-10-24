using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private Transform checkGroundPoint;
        [SerializeField] private float CheckGroundRadius;

        private Vector3 moveDir;
        private float _velocity;
        private InputService _inputService;

        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            
            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDir = moveDirection;
            
            if (IsGround())
            {
                _velocity = -2;
            }
            
            Move(moveDir);
            DoGravity();
        }
        private void Move(Vector3 dir)
        {
            characterController.Move(dir * speed * Time.deltaTime);
        }

        private void DoGravity()
        {
            _velocity += _gravity * Time.deltaTime;
            Move(Vector3.up * _velocity * Time.deltaTime);
        }

        private bool IsGround()
        {
            bool result = Physics.CheckSphere(checkGroundPoint.position, CheckGroundRadius, groundMask);
            return result;
        }
    }
}
