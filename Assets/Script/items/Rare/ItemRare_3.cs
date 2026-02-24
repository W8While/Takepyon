using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemRare_3 : ItemBase
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
            if (_playerStats.GetAspectValue(aspect) == 0)
            {
                switch (aspect)
                {
                    case Aspect.Amaterasu:
                        _playerStats.AmaterasuChange(50);
                        _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy - 10 * _amount);
                        _playerStats.YokayChange(_playerStats.CurrentYokay - 10 * _amount);
                        break;
                    case Aspect.Tsukyomu:
                        _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu - 10 * _amount);
                        _playerStats.TsukyomyChange(50);
                        _playerStats.YokayChange(_playerStats.CurrentYokay - 10 * _amount);
                        break;
                    case Aspect.Yokay:
                        _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu - 10 * _amount);
                        _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy - 10 * _amount);
                        _playerStats.YokayChange(50);
                        break;
                }
            }
        }
    }
}
