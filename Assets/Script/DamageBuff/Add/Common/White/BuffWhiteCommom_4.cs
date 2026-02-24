using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteCommom_4 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            float damage = 0;
            if (_playerStats.CurrentAmaterasu == 0)
                damage += 10;
            if (_playerStats.CurrentTsukyomy == 0)
                damage += 10;
            if (_playerStats.CurrentYokay == 0)
                damage += 10;
            return damage;
        }
    }
}