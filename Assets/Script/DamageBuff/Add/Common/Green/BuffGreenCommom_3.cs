using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenCommom_3 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            if (_playerStats.CurrentAmaterasu <= 70)
                return 0;
            return 100 - _playerStats.CurrentAmaterasu;
        }
    }
}
