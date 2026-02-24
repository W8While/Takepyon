using Game.Building;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInterection : MonoBehaviour
    {
        [SerializeField] private GeneralInputController _controller;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistation;


        private bool _isOpener = false;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _controller.OnUse += OnUse;
        }

        public void OnUse()
        {
            if (_isOpener)
                return;
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit, _maxDistation))
            {
                if (hit.transform.TryGetComponent<BuildingsTrigger>(out BuildingsTrigger component))
                {
                    component.BuildingsOpen();
                    _isOpener = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
            }
        }

        public void ExitPanel()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isOpener = false;
        }
    }
}
