using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Koko
{
    public class KokoTalk : MonoBehaviour, ITalkSetterUI
    {
        [SerializeField] private float _minTimeBetweenReplics;
        [SerializeField] private float _maxTimeBetweenReplics;

        private List<string> _replics = new List<string>();

        public event Action<string> SetTalkUI;

        private void Start()
        {
            _replics.Add(StringsUI.KokoPassiveReplic_1);
            _replics.Add(StringsUI.KokoPassiveReplic_2);
            _replics.Add(StringsUI.KokoPassiveReplic_3);
            _replics.Add(StringsUI.KokoPassiveReplic_4);
            _replics.Add(StringsUI.KokoPassiveReplic_5);
            StartCoroutine(StartReplics());
        }

        private IEnumerator StartReplics()
        {
            while (true)
            {
                float timeBetweenReplics = UnityEngine.Random.Range(_minTimeBetweenReplics, _maxTimeBetweenReplics);
                WaitForSeconds wait = new WaitForSeconds(timeBetweenReplics);
                yield return wait;
                string replic = _replics[UnityEngine.Random.Range(0, _replics.Count)];
                SetTalkUI?.Invoke(replic);
            }
        }
    }
}
