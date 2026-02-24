using Game.Enemy;
using Game.Player;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private ObjectsScriptibleObjects _weaponScriptibleObjects;
        public ObjectsScriptibleObjects WeaponScriptibleObjects => _weaponScriptibleObjects;
        [SerializeField] protected EnemySpawn _enemySpawn;
        protected PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
        }

        protected void GetDamageEnemyInRadius(float radius)
        {
            Collider[] cols = Physics.OverlapSphere(_playerStats.transform.position, radius);
            foreach (Collider col in cols)
                if (col.TryGetComponent(out EnemyTrigger enemyTrigger))
                    _playerStats.GetDamageEnemy(enemyTrigger);
        }

        protected void GetDamageEnemyAmount(int amount)
        {
            if (_enemySpawn.AllEnemy.Count <= 0)
                return;
            if (_enemySpawn.AllEnemy.Count <= amount)
            {
                GetDamageEnemyAll();
                return;
            }
            List<int> enemyIndexToGetDamage = new List<int>();
            while (enemyIndexToGetDamage.Count < amount)
            {
                int newIndex = UnityEngine.Random.Range(0, _enemySpawn.AllEnemy.Count);
                bool flag = false;
                foreach (int enemyIndex in enemyIndexToGetDamage)
                {
                    if (enemyIndex == newIndex)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)           
                    continue;
                enemyIndexToGetDamage.Add(newIndex);
            }
            List<EnemyTrigger> enemyToGetDamage = new List<EnemyTrigger>();

            foreach (int enemyIndex in enemyIndexToGetDamage)
                enemyToGetDamage.Add(_enemySpawn.AllEnemy[enemyIndex]);

            foreach (EnemyTrigger enemy in enemyToGetDamage)
                if (enemy.gameObject.activeSelf)
                    _playerStats.GetDamageEnemy(enemy);
        }

        protected void GetDamageEnemyAll()
        {
            List<EnemyTrigger> enemyToGetDamage = new List<EnemyTrigger>();
            foreach (EnemyTrigger enemyTrigger in _enemySpawn.AllEnemy)
                enemyToGetDamage.Add(enemyTrigger);
            foreach (EnemyTrigger enemyTrigger in enemyToGetDamage)
                if (enemyTrigger.gameObject.activeSelf)
                    _playerStats.GetDamageEnemy(enemyTrigger);
        }
    }
}
