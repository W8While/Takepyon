using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_6 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentAmaterasu >= 45 && _playerStats.CurrentAmaterasu <= 55 ||
                _playerStats.CurrentTsukyomy >= 45 && _playerStats.CurrentTsukyomy <= 55 ||
                _playerStats.CurrentYokay >= 45 && _playerStats.CurrentYokay <= 55)
                return 2f;
            return 0f;
        }
    }
}
