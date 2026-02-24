using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerCommon_2 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            if (_playerStats.CurrentTsukyomy > _playerStats.CurrentAmaterasu && _playerStats.CurrentTsukyomy > _playerStats.CurrentYokay)
                return 1.3f;
            return 0f;
        }
    }
}
