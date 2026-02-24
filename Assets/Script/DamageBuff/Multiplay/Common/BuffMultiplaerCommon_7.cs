using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_7 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentYokay + _playerStats.CurrentAmaterasu - _playerStats.CurrentYokay > 100)
                return 1.7f;
            return 0f;
        }
    }
}
