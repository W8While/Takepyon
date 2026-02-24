using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_1 : ItemBase
    {
        private PlayerStats _playerStats;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _playerStats.GetDamage += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _playerStats.GetDamage -= OnUse;
        }

        private void OnUse(float damage)
        {
            _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu + 1 * _amount);
        }
    }
}