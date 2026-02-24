using Game.Enemy;
using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Item
{
    public class ItemRare_5 : ItemBase
    {
        private PlayerStats _playerStats;
        private bool _isEnable;
        public override void Init(PlayerStats playerStats)
        {
            if (_amount == 0)
            {
                _isEnable = true;
                _playerStats = playerStats;
                StartCoroutine(OnUse());
            }
            _amount++;
        }

        protected override void DisableItem()
        {
            _isEnable = false;
        }

        private IEnumerator OnUse()
        {
            while (_isEnable)
            {
                Collider[] cols = Physics.OverlapSphere(_playerStats.transform.position, 7f);
                int amount = 0;
                foreach (Collider col in cols)
                {
                    if (col.GetComponent<EnemyTrigger>())
                        amount++;
                }
                if (amount >= 5)
                {
                    _playerStats.AmaterasuChange(_playerStats.CurrentAmaterasu + 1 * amount);
                    _playerStats.TsukyomyChange(_playerStats.CurrentTsukyomy + 1 * amount);
                    _playerStats.YokayChange(_playerStats.CurrentYokay + 1 * amount);
                }
                yield return new WaitForSeconds(3);
            }
            yield break;
        }
    }
}
