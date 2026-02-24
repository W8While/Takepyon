using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerRare_1 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            float damage = (_playerStats.CurrentAmaterasu + _playerStats.CurrentTsukyomy + _playerStats.CurrentYokay) / 30;
            return damage;
        }
    }
}
