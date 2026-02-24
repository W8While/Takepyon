using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class MiniatureRoseInstance : WeaponBase
    {
        private MiniatureRoseData _skillData => (MiniatureRoseData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            _enemySpawn.EnemyDies += EnemyDies;
        }

        private void EnemyDies(EnemyTrigger enemy)
        {
            GetDamageEnemyAll();
        }
    }
}