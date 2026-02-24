using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_3 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentAmaterasu == 0 && _playerStats.CurrentAmaterasu == 100)
                return 1.4f;
            if (_playerStats.CurrentTsukyomy == 0 && _playerStats.CurrentTsukyomy == 100)
                return 1.4f;
            if (_playerStats.CurrentYokay == 0 && _playerStats.CurrentYokay == 100)
                return 1.4f;
            return 1f;
        }
    }
}
