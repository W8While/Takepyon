using Game.Enemy;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public class ChineledTogetherInstance : WeaponBase
    {
        private ChineledTogetherData _skillData => (ChineledTogetherData)WeaponScriptibleObjects;

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
                if (_amaterasuValue == _tsukyomuValue || _tsukyomuValue == _yokayValue || _amaterasuValue == _yokayValue)
                    GetDamageEnemyAll();
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}