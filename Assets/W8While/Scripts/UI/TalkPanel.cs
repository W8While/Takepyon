using Game.Koko;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class TalkPanel : InteractionUI
    {
        [Header("UI")]
        [SerializeField] private TMP_Text _talkText;

        [Header("EventComponent")]
        private List<ITalkSetterUI> _talks;

        [Header("Settings")]
        [SerializeField] private float _timeToCloseTalk;
        private float _timerToClostTakl;
        private bool _isOpen;

        private void Awake()
        {
            GetInterfaceFromClass<ITalkSetterUI>(out _talks);
            foreach (ITalkSetterUI talk in _talks)
                talk.SetTalkUI += SetTalk;
            _isOpen = false;
            _timerToClostTakl = 0;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!_isOpen)
                return;
            _timerToClostTakl += Time.deltaTime;
            if (_timerToClostTakl >= _timeToCloseTalk)
                CloseTalk();
        }

        private void SetTalk(string text)
        {
            _isOpen = true;
            _talkText.text = text;
            _timerToClostTakl = 0;
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }

        private void CloseTalk()
        {
            _isOpen = false;
            _timerToClostTakl = 0;

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            foreach (ITalkSetterUI talk in _talks)
                talk.SetTalkUI -= SetTalk;
        }
    }
}