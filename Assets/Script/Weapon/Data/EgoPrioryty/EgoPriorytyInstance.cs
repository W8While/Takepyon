using Game.Enemy;
using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    public class EgoPriorytyInstance : WeaponBase
    {
        private EgoPriorytyData _skillData => (EgoPriorytyData)WeaponScriptibleObjects;

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
                switch (_skillData.Aspect)
                {
                    case Aspect.Amaterasu:
                        if (_playerStats.GetAspectValue(_skillData.Aspect) > _tsukyomuValue && (_playerStats.GetAspectValue(_skillData.Aspect) > _yokayValue))
                            GetDamageEnemyAmount(_skillData.MaxEnemy);
                        break;
                    case Aspect.Tsukyomu:
                        if (_playerStats.GetAspectValue(_skillData.Aspect) > _amaterasuValue && (_playerStats.GetAspectValue(_skillData.Aspect) > _yokayValue))
                            GetDamageEnemyAmount(_skillData.MaxEnemy);
                        break;
                    case Aspect.Yokay:
                        if (_playerStats.GetAspectValue(_skillData.Aspect) > _tsukyomuValue && (_playerStats.GetAspectValue(_skillData.Aspect) > _amaterasuValue))
                            GetDamageEnemyAmount(_skillData.MaxEnemy);
                        break;
                }
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}
