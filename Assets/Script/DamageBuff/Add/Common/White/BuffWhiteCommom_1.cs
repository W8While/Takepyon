using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteCommom_1 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            if (_playerStats.CurrentAmaterasu > (_playerStats.CurrentTsukyomy + _playerStats.CurrentYokay))
                return 10;
            return 0;
        }
    }
}