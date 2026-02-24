using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_10 : ItemBase
    {
        private PlayerStats _playerStats;
        private bool _isEnable;
        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _isEnable = true;
                _playerStats = playerStats;
                StartCoroutine(OnUse());
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _isEnable = false;
        }

        private IEnumerator OnUse()
        {
            while (_isEnable)
            {
                if (_playerStats.CurrentAmaterasu == _playerStats.CurrentTsukyomy && _playerStats.CurrentAmaterasu == _playerStats.CurrentYokay)
                {
                    yield return new WaitForSeconds(2);
                    continue;
                }
                if (_playerStats.CurrentAmaterasu == _playerStats.CurrentTsukyomy)
                    _playerStats.YokayChange(_playerStats.CurrentYokay + 5 * _amount);
                if (_playerStats.CurrentAmaterasu == _playerStats.CurrentYokay)
                    _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy + 5 * _amount);
                if (_playerStats.CurrentTsukyomy == _playerStats.CurrentYokay)
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu + 5 * _amount);
                yield return new WaitForSeconds(2);
            }
            yield break;
        }
    }
}