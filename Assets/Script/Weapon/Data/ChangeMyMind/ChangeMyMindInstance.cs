using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Weapon
{
    public class ChangeMyMindInstance : WeaponBase
    {
        private ChangeMyMindData _skillData => (ChangeMyMindData)WeaponScriptibleObjects;

        private void OnEnable()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
            _playerStats.AspectChange += AspectChange;
        }

        private void AspectChange(Aspect aspect)
        {
            GetDamageEnemyInRadius(_skillData.Radius);
        }
    }
}