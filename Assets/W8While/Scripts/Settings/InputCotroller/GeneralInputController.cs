using System;
using UnityEngine;

namespace Settings
{
    public class GeneralInputController : MonoBehaviour
    {
        private InputController _inputController;

        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnRotate;
        public event Action<bool> OnSpeedUp;
        public event Action OnJump;
        public event Action OnIntetaction;
        public event Action OnStartReading;

        private void OnEnable()
        {
            _inputController = new InputController();
            _inputController.Enable();

            _inputController.KeybordAndMouse.Move.performed += Move_performed;
            _inputController.KeybordAndMouse.Move.canceled += Move_canceled;
            _inputController.KeybordAndMouse.SpeedUp.performed += SpeedUp_performed;
            _inputController.KeybordAndMouse.SpeedUp.canceled += SpeedUp_canceled;
            _inputController.KeybordAndMouse.Rotate.performed += Rotate_performed;
            _inputController.KeybordAndMouse.Jump.performed += Jump_performed;
            _inputController.KeybordAndMouse.Interaction.performed += Interaction_performed;
            _inputController.KeybordAndMouse.ReadDairy.performed += ReadDairy_performed;
        }

        private void ReadDairy_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnStartReading?.Invoke();
        }

        private void Interaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnIntetaction?.Invoke();
        }

        private void SpeedUp_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnSpeedUp?.Invoke(false);
        }

        private void SpeedUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnSpeedUp?.Invoke(true);
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void Rotate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnRotate?.Invoke(obj.action.ReadValue<Vector2>());
        }

        private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnMove?.Invoke(obj.action.ReadValue<Vector2>());
        }

        private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnMove?.Invoke(obj.action.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _inputController.KeybordAndMouse.Move.performed -= Move_performed;
            _inputController.KeybordAndMouse.Move.canceled -= Move_canceled;
            _inputController.KeybordAndMouse.SpeedUp.performed -= SpeedUp_performed;
            _inputController.KeybordAndMouse.SpeedUp.canceled -= SpeedUp_canceled;
            _inputController.KeybordAndMouse.Rotate.performed -= Rotate_performed;
            _inputController.KeybordAndMouse.Jump.performed -= Jump_performed;
            _inputController.KeybordAndMouse.Interaction.performed -= Interaction_performed;
            _inputController.KeybordAndMouse.ReadDairy.performed -= ReadDairy_performed;

            _inputController.Disable();
        }
    }
}
