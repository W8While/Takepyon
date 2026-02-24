using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_1 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentYokay > _playerStats.CurrentAmaterasu &&
                _playerStats.CurrentAmaterasu > _playerStats.CurrentTsukyomy)
                return 1.5f;
            return 0f;
        }
    }
}
