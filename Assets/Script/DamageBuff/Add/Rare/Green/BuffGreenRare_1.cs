using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenRare_1 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            return _playerStats.CurrentAmaterasu;
        }
    }
}