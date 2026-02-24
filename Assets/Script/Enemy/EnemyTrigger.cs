using UnityEngine;

namespace Game.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        private EnemyStats _enemyStats;

        private void Awake()
        {
            _enemyStats = GetComponent<EnemyStats>();
        }

        public EnemyStats GetEnemyStats()
        {
            return _enemyStats;
        }
    }
}
