using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Weapon
{
    public class DifferenceMindInstance : WeaponBase
    {
        private DifferenceMindData _skillData => (DifferenceMindData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats.AspectChange += AspectChange;
        }

        private void AspectChange(Aspect aspect)
        {
            if (aspect != _skillData.Aspect)
                return;
            GetDamageEnemyInRadius(_skillData.Radius);
        }
    }
}