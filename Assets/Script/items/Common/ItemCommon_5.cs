using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_5 : ItemBase
    {
        private PlayerStats _playerStats;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _playerStats.GetDamageSomeEnemy += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _playerStats.GetDamageSomeEnemy -= OnUse;
        }

        private void OnUse(int count)
        {
            if (count == 5)
                _playerStats.YokayChange(_playerStats.CurrentYokay + 3 * _amount);
        }
    }
}