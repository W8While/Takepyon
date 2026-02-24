using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteCommom_6 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            if (_playerStats.CurrentAmaterasu > 40 && _playerStats.CurrentAmaterasu < 60)
                return 10;
            if (_playerStats.CurrentTsukyomy > 40 && _playerStats.CurrentTsukyomy < 60)
                return 10;
            if (_playerStats.CurrentYokay > 40 && _playerStats.CurrentYokay < 60)
                return 10;
            return 0;
        }
    }
}