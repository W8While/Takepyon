using UnityEngine;

namespace Game.Damage
{
    public class BuffGreenCommom_2 : DamageBuffBase, IDamageBuffAddGreen
    {
        public float DamageBuffAddGreen()
        {
            if (Mathf.Abs(_playerStats.CurrentAmaterasu - _playerStats.CurrentTsukyomy) <= 5 && 
                Mathf.Abs(_playerStats.CurrentYokay - _playerStats.CurrentTsukyomy) <= 5 && 
                Mathf.Abs(_playerStats.CurrentAmaterasu - _playerStats.CurrentYokay) <= 5)
                return 20;
            return 0;
        }
    }
}
