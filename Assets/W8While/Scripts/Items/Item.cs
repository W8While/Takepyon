using System;
using UnityEngine;

namespace Game.Item
{
    public class Item : MonoBehaviour, IClickInteraction
    {
        [SerializeField] private Transform _cameraInspectionPosition;

        public event Action<string> StartInteractionUI;
        public event Action StopInteractionUI;

        public void ClickInteraction(Action<Vector3, Vector3> StartInteraction)
        {
            StartInteraction(_cameraInspectionPosition.position, _cameraInspectionPosition.eulerAngles);
        }

        public void StartFocus()
        {
            StartInteractionUI?.Invoke(GetStartFocusString());
        }
        protected virtual string GetStartFocusString()
        {
            return StringsUI.ItemInteractionTake;
        }

        public void StopFocus()
        {
            StopInteractionUI?.Invoke();
        }
    }
}