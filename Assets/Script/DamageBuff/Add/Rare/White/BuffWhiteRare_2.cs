using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteRare_2 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            float damage = (_playerStats.CurrentYokay - _playerStats.CurrentAmaterasu + _playerStats.CurrentTsukyomy)/2;
            if (damage > 0)
                return damage;
            return 0;
        }
    }
}
