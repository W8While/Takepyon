using Settings;
using System;
using UnityEngine;

namespace Game.Koko
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private Transform _raycastPosition;
        [SerializeField] private float _raycastMaxDistance;
        [SerializeField] private GeneralInputController _generalInputController;

        private IInteractionFocus _lastInteraction;
        private MoveController _moveController;

        private bool _isInteractionActive;
        private IClickInteraction _activeInteraction;
        private bool _isReadingActive;

        private void Awake()
        {
            _moveController = GetComponent<MoveController>();
            _isInteractionActive = _isReadingActive = false;
        }

        private void OnEnable()
        {
            _generalInputController.OnIntetaction += OnInteraction;
            _generalInputController.OnStartReading += OnStartReading;
        }

        private void Update()
        {
            if (!_isInteractionActive)
                if (Physics.Raycast(_raycastPosition.position, _raycastPosition.forward, out RaycastHit ray, _raycastMaxDistance))
                    if (ray.collider.TryGetComponent<IInteractionFocus>(out IInteractionFocus _currentInteraction))
                    {
                        if (_lastInteraction != _currentInteraction)
                        {
                            _lastInteraction?.StopFocus();
                            _currentInteraction.StartFocus();
                            _lastInteraction = _currentInteraction;
                        }
                        return;
                    }
            if (_lastInteraction != null)
            {
                _lastInteraction.StopFocus();
                _lastInteraction = null;
            }
        }

        private void OnInteraction()
        {
            if (_isInteractionActive)
            {
                StopInteraction();
                if (_isReadingActive)
                {
                    IClickInteractionDairy _iClickInteractionDairy = (IClickInteractionDairy)_activeInteraction;
                    _iClickInteractionDairy.StopInteractionDairy();
                }
                return;
            }
            if (_lastInteraction is IClickable clickible)
                clickible.Click();
            if (_lastInteraction is IClickInteraction clickInteraction)
            {
                clickInteraction.ClickInteraction(StartCameraInteraction);
                _activeInteraction = clickInteraction;
            }
        }
        private void OnStartReading()
        {
            if (!_isInteractionActive)
                return;
            IClickInteractionDairy _iClickInteractionDairy;
            if (_activeInteraction is IClickInteractionDairy iClickInteractionDairy)
                _iClickInteractionDairy = iClickInteractionDairy;
            else
                return;
            if (_isReadingActive)
            {
                _isReadingActive = false;
                _iClickInteractionDairy.StopInteractionDairy();
            }
            else
            {
                _isReadingActive = true;
                iClickInteractionDairy.StartInteractionDairy();
            }
        }
        private void StartCameraInteraction(Vector3 pos, Vector3 rot)
        {
            _isInteractionActive = true;
            _moveController.LockCamera(pos, rot);
        }
        private void StopInteraction()
        {
            _moveController.EnableCamera();
            _isInteractionActive = false;
        }

        private void OnDisable()
        {
            _generalInputController.OnIntetaction -= OnInteraction;
        }
    }
}
