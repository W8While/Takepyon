using Game.Building;
using UnityEngine;

namespace Game.Enemy.Building.Boss
{
    public class EnemyBossTrigger : BuildingsTrigger
    {
        [SerializeField] private GameObject _bossObject;

        protected override void Open()
        {
            Debug.Log(123);
            _enemySpawn.SpawnBoss(_bossObject, transform);
            _buildingsManager.SpawnBoss();
        }
    }
}
