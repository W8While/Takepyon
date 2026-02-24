using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class SlamBongInstance : WeaponBase
    {
        private SlamBongData _skillData => (SlamBongData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                GetDamageEnemyAll();
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
