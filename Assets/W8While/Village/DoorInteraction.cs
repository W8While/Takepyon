using System;
using System.Collections;
using UnityEngine;

namespace Game.Village.Interaction
{
    public class DoorInteraction : FurnitureInteraction, ITalkSetterUI
    {
        [SerializeField] private Vector3 _endRotation;

        public event Action<string> SetTalkUI;

        private void Start()
        {
            _openPosition = -1;
        }

        public override void Click()
        {
            if (_isClose)
            {
                TryOpenCloseDoor();
                return;
            }    
            if (_openPosition == 0)
                return;
            StopFocus();
            switch (_openPosition)
            {
                case -1:
                    OpenDoor();
                    break;
                case 1:
                    CloseDoor();
                    break;
                default:
                    break;
            }
            _openPosition = 0;
        }

        protected override string GetFocusLiteral()
        {
            return _openPosition == 1 ? StringsUI.DoorInteractionClose : StringsUI.DoorInteractionOpen;
        }

        private void OpenDoor()
        {
            float startAngle = transform.localEulerAngles.y;
            StartCoroutine(RotateDoor(startAngle, _endRotation.y, 1));
        }

        private void CloseDoor()
        {
            float startAngle = transform.localEulerAngles.y;
            StartCoroutine(RotateDoor(startAngle, 0, -1));
        }

        private void TryOpenCloseDoor()
        {
            SetTalkUI?.Invoke(StringsUI.TalkDoorClose);
        }



        private IEnumerator RotateDoor(float startAngle, float endAngle, int isOpenValue)
        {
            while (Mathf.Abs(Mathf.DeltaAngle(startAngle, endAngle)) >= 0.1f)
            {
                float newAngle = Mathf.MoveTowardsAngle(startAngle, endAngle, _openerSpeed * Time.deltaTime);
                Vector3 euler = transform.localEulerAngles;
                euler.y = newAngle;
                transform.localEulerAngles = euler;
                startAngle = transform.localEulerAngles.y;
                yield return null;
            }
            _openPosition = isOpenValue;
            yield break;
        }
    }
}
