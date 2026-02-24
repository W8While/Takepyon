using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_4 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentAmaterasu + _playerStats.CurrentTsukyomy + _playerStats.CurrentYokay < 200)
                return 1.5f;
            return 0f;
        }
    }
}
