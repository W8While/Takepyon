using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Weapon
{
    public class BollrazeInstance : WeaponBase
    {
        private BollrazeData _skillData => (BollrazeData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            _enemySpawn.SpawmEnemy += SpawnEnemy;
        }

        private void SpawnEnemy(EnemyTrigger enemyTrigger)
        {
            _playerStats.GetDamageEnemy(enemyTrigger);
        }
    }
}
