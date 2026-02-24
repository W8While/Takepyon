using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_6 : ItemBase
    {
        private PlayerStats _playerStats;

        private float _distance;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _playerStats.GetComponent<PlayerMove>().MoveDistance += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _playerStats.GetComponent<PlayerMove>().MoveDistance -= OnUse;
        }

        private void OnUse(float distance)
        {
            _distance += distance;
            Debug.Log("Прошел " + _distance);
            if (_distance >= 5)
            {
                _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy + 1 * _amount);
                _distance = 0;
            }
        }
    }
}