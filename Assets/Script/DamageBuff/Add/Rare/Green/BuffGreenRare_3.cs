using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenRare_3 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            return _playerStats.CurrentYokay;
        }
    }
}