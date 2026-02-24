using UnityEngine;

namespace Game.Damage
{
    public class BuffMultiplaerRare_3 : DamageBuffBase, IDamageBuffMultiplay
    {
        public float DamageBuffAddMultiplay()
        {
            return _playerStats.CurrentYokay / 20;
        }
    }
}
