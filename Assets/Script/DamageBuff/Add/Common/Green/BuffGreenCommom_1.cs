using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenCommom_1 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            if (_playerStats.CurrentTsukyomy < _playerStats.CurrentAmaterasu && _playerStats.CurrentAmaterasu < _playerStats.CurrentYokay)
                return 15;
            return 0;
        }
    }
}
