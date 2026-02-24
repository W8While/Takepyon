using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class MidDiffInstance : WeaponBase
    {
        private MidDiffData _skillData => (MidDiffData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                float _amaterasuValue = _playerStats.GetAspectValue(Aspect.Amaterasu);
                float _tsukyomuValue = _playerStats.GetAspectValue(Aspect.Tsukyomu);
                float _yokayValue = _playerStats.GetAspectValue(Aspect.Yokay);
                List<float> values = new List<float> { _amaterasuValue, _tsukyomuValue, _yokayValue };
                values.Sort();
                if (values[0] - values[2] > 40)
                    GetDamageEnemyAmount(_skillData.MaxEnemy);
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
