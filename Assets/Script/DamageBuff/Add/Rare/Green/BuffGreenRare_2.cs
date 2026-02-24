using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenRare_2 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            return _playerStats.CurrentTsukyomy;
        }
    }
}