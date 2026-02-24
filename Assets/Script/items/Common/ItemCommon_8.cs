using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemCommon_8 : ItemBase
    {
        [SerializeField] private EnemySpawn _enemySpawn;
        private PlayerStats _playerStats;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _enemySpawn.EnemyDies += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _enemySpawn.EnemyDies -= OnUse;
        }

        private void OnUse(EnemyTrigger enemyTrigger)
        {
            _playerStats.YokayChange(_playerStats.CurrentYokay + 2 * _amount);
        }
    }
}