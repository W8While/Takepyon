using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemRare_4 : ItemBase
    {
        private PlayerStats _playerStats;

        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _playerStats = playerStats;
                _playerStats.AspectChange += OnUse;
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _playerStats.AspectChange -= OnUse;
        }

        private void OnUse(Aspect aspect)
        {
            switch (aspect)
            {
                case Aspect.Amaterasu:
                    _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy - 1 * _amount);
                    _playerStats.YokayChange(_playerStats.CurrentYokay - 1 * _amount);
                    break;
                case Aspect.Tsukyomu:
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu - 1 * _amount);
                    _playerStats.YokayChange(_playerStats.CurrentYokay - 1 * _amount);
                    break;
                case Aspect.Yokay:
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu - 1 * _amount);
                    _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy - 1 * _amount);
                    break;
            }
        }
    }
}
