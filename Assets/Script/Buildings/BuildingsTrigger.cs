using Game.Enemy;
using Game.Player;
using UnityEngine;

namespace Game.Building
{
    public class BuildingsTrigger : MonoBehaviour
    {
        protected BuildingsManager _buildingsManager;
        protected EnemySpawn _enemySpawn;

        public void Init(BuildingsManager buildingsManager, EnemySpawn enemySpawn)
        {
            _buildingsManager = buildingsManager;
            _enemySpawn = enemySpawn;
        }

        public void BuildingsOpen()
        {
            Open();
        }

        protected virtual void Open()
        {
        }
    }
}