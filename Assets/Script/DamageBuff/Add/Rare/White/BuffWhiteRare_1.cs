using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteRare_1 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            float damage = _playerStats.CurrentTsukyomy - _playerStats.CurrentYokay;
            if (damage > 0)
                return damage;
            return 0;
        }
    }
}
