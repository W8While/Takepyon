using System;
using UnityEngine;

namespace Game.Item.Dairy
{
    public class Dairy : Item, IClickInteractionDairy
    {
        [SerializeField] private DairyBase _dairyBase;

        public event Action<DairyBase> StartDairyReading;
        public event Action StopDairyReading;

        public void StartInteractionDairy()
        {
            StartDairyReading?.Invoke(_dairyBase);
        }

        public void StopInteractionDairy()
        {
            StopDairyReading?.Invoke();
        }

        protected override string GetStartFocusString()
        {
            return StringsUI.DairyInteractionBase_1;
        }
    }
}