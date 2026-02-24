using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_4 : ItemBase
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
            _playerStats.YokayChange(_playerStats.CurrentYokay - 2 * _amount);
            _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy + 1 * _amount);
        }
    }
}