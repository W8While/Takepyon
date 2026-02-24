using Game.Enemy;
using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    public class LittleBustardInstance : WeaponBase
    {
        private LittleBustardData _skillData => (LittleBustardData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                if (_playerStats.GetAspectValue(_skillData.Aspect) < _skillData.MinClamp)
                    GetDamageEnemyInRadius(_skillData.Radius);
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
