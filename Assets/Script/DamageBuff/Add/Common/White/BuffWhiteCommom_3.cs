using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteCommom_3 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            if (_playerStats.CurrentYokay < 20)
                return 10;
            return 0;
        }
    }
}