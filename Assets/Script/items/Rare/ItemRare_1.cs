using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemRare_1 : ItemBase
    {
        [SerializeField] private EnemySpawn _enemySpawn;
        private PlayerStats _playerStats;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _enemySpawn.SpawmEnemy += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _enemySpawn.SpawmEnemy -= OnUse;
        }

        private void OnUse(EnemyTrigger enemyTrigger)
        {
            int i = UnityEngine.Random.Range(0, 3);
            Aspect[] aspects = new Aspect[]{Aspect.Amaterasu, Aspect.Tsukyomu, Aspect.Yokay};
            switch (aspects[i])
            {
                case Aspect.Amaterasu:
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu - 1 * _amount);
                    break;
                case Aspect.Tsukyomu:
                    _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy- 1 * _amount);
                    break;
                case Aspect.Yokay:
                    _playerStats.YokayChange(_playerStats.CurrentYokay - 1 * _amount);
                    break;
            }
        }
    }
}
