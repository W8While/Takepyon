using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class NearistRakeInstance : WeaponBase
    {
        private NearistRakeData _skillData => (NearistRakeData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                if (_enemySpawn.AllEnemy.Count != 0)
                {
                    float range = Vector3.Distance(_playerStats.transform.position, _enemySpawn.AllEnemy[0].transform.position);
                    EnemyTrigger enemyTrigger = _enemySpawn.AllEnemy[0];
                    foreach (EnemyTrigger enemy in _enemySpawn.AllEnemy)
                    {
                        if (Vector3.Distance(_playerStats.transform.position, enemy.transform.position) <= range)
                        {
                            range = Vector3.Distance(_playerStats.transform.position, enemy.transform.position);
                            enemyTrigger = enemy;
                        }
                    }
                    _playerStats.GetDamageEnemy(enemyTrigger);
                }
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
