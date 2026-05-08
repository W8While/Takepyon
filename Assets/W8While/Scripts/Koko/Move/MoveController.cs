using Settings;
using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.SceneView;
using static UnityEngine.Rendering.DebugUI.Table;

namespace Game.Koko
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private GeneralInputController _generalInputController;
        [SerializeField] private Transform _camera;
        private CharacterController _characterController;


        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _fastMoveSpeed;
        public float FastMoveSpeed => _fastMoveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _jumpForce;
        private float _gravity;

        [SerializeField] private float _cameraMoveSpeed;
        [SerializeField] private float _cameraRotateSpeed;



        private Vector2 _direction;
        private float _attraction;
        private float _topCameraClamp;
        private float _botCameraClamp;
        private float _xCameraRotation;
        private float _currentMoveSpeed;
        private bool _isSpeedUp;
        private Vector3 _cameraPosDefault;
        private Vector3 _cameraRotDefault;
        private bool _isCameraLock;
        private bool _isCameraMoving;
        private Coroutine _cameraMove;

        public event Action<Vector2, float> OnMove;
        public event Action OnJump;

        private void OnEnable()
        {
            EnableInteraction(true);
        }

        private void SpeedUp(bool obj)
        {
            _isSpeedUp = obj;
            UpdateMove();
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            _direction = Vector2.zero;
            _attraction = 0;
            _xCameraRotation = _camera.localEulerAngles.x;
            _topCameraClamp = 5;
            _botCameraClamp = 35;
            _gravity = 7;
            _isSpeedUp = false;
            _cameraPosDefault = _camera.transform.localPosition;
            _cameraRotDefault = _camera.transform.localEulerAngles;
            _isCameraLock  = _isCameraMoving = false;

            _currentMoveSpeed = _moveSpeed;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            UpdateCurrentMoveSpeed();
            if (_characterController.isGrounded)
            {
                if (_attraction <= 0)
                    _attraction = -2f;
            }
            else
                _attraction -= _gravity * Time.deltaTime;

            Vector3 finalyDirection = new Vector3(_direction.x * _currentMoveSpeed, _attraction, _direction.y * _currentMoveSpeed);
            Vector3 forwardDirection = transform.TransformDirection(finalyDirection);

            _characterController.Move(forwardDirection * Time.deltaTime);
        }


        private void Move(Vector2 obj)
        {
            _direction = obj;
            UpdateMove();
        }

        private void UpdateMove()
        {
            UpdateCurrentMoveSpeed();
            OnMove?.Invoke(_direction, _currentMoveSpeed);
        }

        private void Rotate(Vector2 obj)
        {
            transform.Rotate(_rotateSpeed * obj.x * Time.deltaTime * Vector3.up);

            _xCameraRotation += -obj.y * _rotateSpeed * Time.deltaTime;
            _xCameraRotation = Mathf.Clamp(_xCameraRotation, _topCameraClamp, _botCameraClamp);
        }

        private void Jump()
        {
            if (!_characterController.isGrounded)
                return;
            _attraction = _jumpForce;
            OnJump?.Invoke();
        }

        private void UpdateCurrentMoveSpeed()
        {
            if (_direction.sqrMagnitude <= 0.01f)
                _currentMoveSpeed = 0;
            else
                _currentMoveSpeed = (_direction.y >= 1 && _isSpeedUp) ? _fastMoveSpeed : _moveSpeed;
        }

        public void TeleportToPoint(Vector3 position, float yRotation)
        {
            _characterController.enabled = false;
            transform.position = position;
            transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * yRotation);
            _attraction = -2f;
            _characterController.enabled = true;
        }

        public void MoveStateChange(bool value)
        {
            enabled = value;
        }

        public void LockCamera(Vector3 pos, Vector3 rot)
        {
            _isCameraLock = true;
            if (_cameraMove != null)
                StopCoroutine(_cameraMove);
            _cameraMove = StartCoroutine(CameraMove(pos, rot, false));
            EnableInteraction(false);
        }

        public void EnableCamera()
        {
            EnableInteraction(true);
            if (_cameraMove != null)
                StopCoroutine(_cameraMove);
            _cameraMove = StartCoroutine(CameraMove(_cameraPosDefault, _cameraRotDefault, true));            
            _isCameraLock = false;
        }

        private IEnumerator CameraMove(Vector3 pos, Vector3 rot, bool isLocal)
        {
            _isCameraMoving = true;
            Vector3 startPos = isLocal ? _camera.transform.localPosition : _camera.transform.position;
            Quaternion startRot = isLocal ? _camera.transform.localRotation : _camera.transform.rotation;
            Quaternion lastRot = Quaternion.Euler(rot);
            while ((Vector3.SqrMagnitude(startPos - pos) > 0.001f) ||
                Quaternion.Angle(startRot, lastRot) > 0.001f)
            {
                startPos = isLocal ? _camera.transform.localPosition : _camera.transform.position;
                startRot = isLocal ? _camera.transform.localRotation : _camera.transform.rotation;
                if (isLocal) 
                {
                    _camera.transform.localPosition = Vector3.MoveTowards(_camera.transform.localPosition, pos, _cameraMoveSpeed * Time.deltaTime);
                    _camera.transform.localRotation = Quaternion.RotateTowards(_camera.transform.localRotation, lastRot, _cameraRotateSpeed * Time.deltaTime);
                }
                else
                {
                    _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, pos, _cameraMoveSpeed * Time.deltaTime);
                    _camera.transform.rotation = Quaternion.RotateTowards(_camera.transform.rotation, lastRot, _cameraRotateSpeed * Time.deltaTime);
                }
                yield return null;
            }
            if (isLocal)
                _camera.transform.SetLocalPositionAndRotation(pos, lastRot);
            else
                _camera.transform.SetPositionAndRotation(pos, lastRot);
            _isCameraMoving = false;
            yield break;
        }

        private void EnableInteraction(bool value)
        {
            if (value)
            {
                _generalInputController.OnMove += Move;
                _generalInputController.OnRotate += Rotate;
                _generalInputController.OnJump += Jump;
                _generalInputController.OnSpeedUp += SpeedUp;
                return;
            }
            _generalInputController.OnMove -= Move;
            _generalInputController.OnRotate -= Rotate;
            _generalInputController.OnJump -= Jump;
            _generalInputController.OnSpeedUp -= SpeedUp;
        }

        private void LateUpdate()
        {
            if (_isCameraLock || _isCameraMoving)
                return;
            _camera.transform.localRotation = Quaternion.Euler(_xCameraRotation, 0, 0);
        }

        private void OnDisable()
        {
            EnableInteraction(false);
        }
    }
}
