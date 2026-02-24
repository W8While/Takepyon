using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenCommom_4 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            if (_playerStats.CurrentAmaterasu == _playerStats.CurrentTsukyomy ||
                _playerStats.CurrentTsukyomy == _playerStats.CurrentYokay ||
                _playerStats.CurrentYokay == _playerStats.CurrentAmaterasu)
                return 30;
            return 0;
        }
    }
}
