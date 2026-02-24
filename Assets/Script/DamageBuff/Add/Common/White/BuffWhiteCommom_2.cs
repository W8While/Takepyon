using UnityEngine;

namespace Game.Damage
{
    public class BuffWhiteCommom_2 : DamageBuffBase, IDamageBuffAddWhite
    {
        public float DamageBuffAddWhite()
        {
            if (_playerStats.CurrentTsukyomy >80)
                return 10;
            return 0;
        }
    }
}