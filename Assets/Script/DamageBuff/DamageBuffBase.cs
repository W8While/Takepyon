using Game.Player;
using Game.Weapon;
using UnityEngine;

namespace Game.Damage
{
    public class DamageBuffBase : MonoBehaviour
    {
        [SerializeField] private ObjectsScriptibleObjects _damageScriptibleObjects;
        public ObjectsScriptibleObjects DamageScriptibleObjects => _damageScriptibleObjects;
        protected PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
        }
    }
}
