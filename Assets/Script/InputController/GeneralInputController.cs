using System;
using UnityEngine;

public class GeneralInputController : MonoBehaviour
{
    private InputController _inputController;

    public Action<Vector2> OnMove;
    public Action<Vector2> OnRotate;
    public Action OnJump;
    public Action OnUse;

    private void OnEnable()
    {
        _inputController.Enable();
    }

    private void Awake()
    {
        _inputController = new InputController();
        _inputController.Player.Move.performed += Move;
        _inputController.Player.Move.canceled += Move;
        _inputController.Player.Rotate.performed += Rotate_performed;
        _inputController.Player.Jump.performed += Jump_performed;
        _inputController.Player.Use.performed += Use_performed;
    }

    private void Use_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnUse?.Invoke();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }

    private void Rotate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnRotate?.Invoke(obj.action.ReadValue<Vector2>());
    }

    private void Move(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMove?.Invoke(obj.action.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        _inputController.Disable();
    }

}
