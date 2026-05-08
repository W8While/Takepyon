using System;
using UnityEngine;

namespace Game.Village.Interaction
{
    public abstract class FurnitureInteraction : MonoBehaviour, IClickable
    {
        [SerializeField] protected bool _isClose;
        [SerializeField] protected float _openerSpeed;
        protected int _openPosition;

        public event Action<string> StartInteractionUI;
        public event Action StopInteractionUI;

        public abstract void Click();

        public void StartFocus()
        {
            StartInteractionUI?.Invoke(GetFocusLiteral());
        }
        protected abstract string GetFocusLiteral();

        public void StopFocus()
        {
            StopInteractionUI?.Invoke();
        }
    }
}
