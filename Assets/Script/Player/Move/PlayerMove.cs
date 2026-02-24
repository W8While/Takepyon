using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private GeneralInputController _inputController;
        [SerializeField] private Transform _camera;

        private CharacterController _characterController;

        [SerializeField] private float _moveSpeed;
        private float _currentMoveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravity;
        [SerializeField] private float _cameraClampMin;
        [SerializeField] private float _cameraClampMax;

        [SerializeField] private float _bhopTimeDelta;
        [SerializeField] private float _multiplayBhopForce;
        private float _currentBhopTimeDelta;

        private Vector3 _moveDirection;
        private float _cameraVerticalRotation;

        public Action<float> MoveDistance;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputController.OnMove += OnMove;
            _inputController.OnRotate += OnRotate;
            _inputController.OnJump += OnJump;

            _currentMoveSpeed = _moveSpeed;
        }

        void Update()
        {
            if (!_characterController.isGrounded)
            {
                _moveDirection.y -= _gravity * Time.deltaTime;
                _currentBhopTimeDelta = 0;
            }
            else
            {
                if (_moveDirection.y <= 0)
                    _moveDirection.y = -2;
            }

            Vector3 _transformDirection = transform.TransformDirection(_moveDirection) * _currentMoveSpeed * Time.deltaTime;
            MoveDistance?.Invoke(_transformDirection.magnitude);
            _characterController.Move(_transformDirection);

            if (_currentBhopTimeDelta > _bhopTimeDelta)
            {
                _currentMoveSpeed = _moveSpeed;
                return;
            }
            _currentBhopTimeDelta += Time.deltaTime;
        }

        private void OnMove(Vector2 direction)
        {
            _moveDirection.x = direction.x;
            _moveDirection.z = direction.y;
        }

        private void OnRotate(Vector2 direction) 
        {
            _cameraVerticalRotation += -direction.y * Time.deltaTime * _rotateSpeed;
            _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, _cameraClampMin, _cameraClampMax);
            _camera.transform.localRotation= Quaternion.Euler(_cameraVerticalRotation, 0, 0);

            float playerRotate = direction.x * Time.deltaTime * _rotateSpeed;
            transform.Rotate(0, playerRotate, 0);
        }

        private void OnJump()
        {
            if (!_characterController.isGrounded)
                return;

            if (_currentBhopTimeDelta <= _bhopTimeDelta)
                _currentMoveSpeed *= _multiplayBhopForce;

            _moveDirection.y = _jumpForce;
        }
    }
}
