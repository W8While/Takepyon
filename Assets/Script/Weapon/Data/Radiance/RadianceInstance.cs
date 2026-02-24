using Game.Enemy;
using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    public class RadianceInstance : WeaponBase
    {
        private RadianceData _skillData => (RadianceData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                GetDamageEnemyInRadius(_skillData.Radius);
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
