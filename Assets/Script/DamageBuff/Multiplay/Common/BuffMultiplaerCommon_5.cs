using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_5 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentAmaterasu >= 50 && _playerStats.CurrentTsukyomy >= 50 && _playerStats.CurrentYokay >= 50)
                return 1.8f;
            return 0f;
        }
    }
}
