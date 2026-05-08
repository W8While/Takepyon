using System;
using System.Collections;
using UnityEngine;

namespace Game.Village.Interaction
{
    public class WardrobeInteraction : FurnitureInteraction
    {
        [SerializeField] private Vector3 _endPosition;

        private void Start()
        {
            _openPosition = -1;
        }
        public override void Click()
        {
            if (_isClose)
            {
                //TryOpenCloseDoor();
                return;
            }
            if (_openPosition == 0)
                return;
            StopFocus();
            switch (_openPosition)
            {
                case -1:
                    OpenWardrobel();
                    break;
                case 1:
                    CloseWardrobel();
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

        private void OpenWardrobel()
        {
            StartCoroutine(TranslateWardrobel(transform.localPosition, transform.localPosition + _endPosition, 1));
        }

        private void CloseWardrobel()
        {
            StartCoroutine(TranslateWardrobel(transform.localPosition, transform.localPosition - _endPosition, -1));
        }

        private IEnumerator TranslateWardrobel(Vector3 startPosition, Vector3 endPosition, int isOpenValue)
        {
            while (Vector3.Magnitude(startPosition - endPosition) >= 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(startPosition, endPosition, _openerSpeed * Time.deltaTime);
                startPosition = transform.localPosition;
                yield return null;
            }
            _openPosition = isOpenValue;
            yield break;
        }

    }
}
