using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class ChaosOfRandomInstance : WeaponBase
    {
        private ChaosOfRandomData _skillData => (ChaosOfRandomData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                GetDamageEnemyAmount(1);
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
