using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenCommom_5 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            float damage = 0;
            if (_playerStats.CurrentAmaterasu == 100)
                damage += 15;
            if (_playerStats.CurrentTsukyomy == 100)
                damage += 15;
            if (_playerStats.CurrentYokay == 100)
                damage += 15;
            return damage;
        }
    }
}
