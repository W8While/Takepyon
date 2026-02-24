using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    public class EnoughIsEnoughInstance : WeaponBase
    {
        private EnoughIsEnoughData _skillData => (EnoughIsEnoughData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            StartCoroutine(Use());
        }

        private IEnumerator Use()
        {
            while (enabled)
            {
                if (_playerStats.GetAspectValue(_skillData.Aspect) == _skillData.Value)
                    GetDamageEnemyAll();
                yield return new WaitForSeconds(_skillData.CoolDawn);
            }
            yield break;
        }
    }
}