using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_7 : ItemBase
    {
        private PlayerStats _playerStats;

        private bool _isStay;
        private float _timer;

        private bool _isEnable;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _isEnable = true;
                _playerStats = playerStats;
                _playerStats.GetComponent<PlayerMove>().MoveDistance += OnUse;
                StartCoroutine(AddAspect());
            }
            _amount++;
        }

        private void OnUse(float distance)
        {
            if (distance == 0)
                if (_timer >= 3)
                    _isStay = true;
            _timer = 0;
        }

        private IEnumerator AddAspect()
        {
            while (_isEnable)
            {
                if (_isStay)
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu + 1 * _amount);
                yield return new WaitForSeconds(1);
            }
            yield break;
        }


        private void Update()
        {
            if (!_isEnable)
                return;
            _timer += Time.deltaTime;
        }

        protected override void DisableItem()
        {
            _isEnable = false;
            _playerStats.GetComponent<PlayerMove>().MoveDistance -= OnUse;
        }
    }
}