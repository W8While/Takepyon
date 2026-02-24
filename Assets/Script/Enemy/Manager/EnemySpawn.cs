using Game.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Enemy {
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrebuf;
        [SerializeField] private int _enemyCount;

        [SerializeField] private Terrain _terrain;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private float _radiusSpawnMin;
        [SerializeField] private float _radiusSpawnMax;
        [SerializeField] private float _startTimeSpawn;
        [SerializeField] private int _momentEnemyCountMax;

        private List<EnemyTrigger> _allEnemy = new List<EnemyTrigger>();
        public List<EnemyTrigger> AllEnemy => _allEnemy;

        public Action<EnemyTrigger> SpawmEnemy;
        public Action<EnemyTrigger> EnemyDies;

        private void Awake()
        {
            StartCoroutine(PassiveSpawnEmemy());
        }

        private IEnumerator PassiveSpawnEmemy()
        {
            while (true)
            {
                Vector2 playerPosition = new Vector2(_playerTransform.position.x, _playerTransform.position.z);
                float _radiusSpawn = UnityEngine.Random.Range(_radiusSpawnMin, _radiusSpawnMax);
                float _degree = UnityEngine.Random.Range(0, 360);
                _degree = math.radians(_degree);
                float x = _radiusSpawn * math.cos(_degree);
                float z = _radiusSpawn * math.sin(_degree);
                Vector2 positionSpawn = playerPosition + new Vector2(x, z);
                float y = _terrain.SampleHeight(new Vector3(positionSpawn.x, 0, positionSpawn.y));
                y += 1;
                SpawnEnemy(new Vector3(positionSpawn.x, y, positionSpawn.y));
                yield return new WaitForSeconds(_startTimeSpawn);
            }
        }

        private void SpawnEnemy(Vector3 position)
        {
            GameObject enemy = Instantiate(_enemyPrebuf, position, Quaternion.identity);
            enemy.transform.SetParent(transform, false);
            enemy.GetComponent<EnemyStats>().Init(_playerStats);
            EnemyTrigger enemyTrigger = enemy.GetComponent<EnemyTrigger>();
            _allEnemy.Add(enemyTrigger);
            SpawmEnemy?.Invoke(enemyTrigger);
            enemyTrigger.GetComponent<EnemyStats>().Dies += EnemyDie;
        }

        private void EnemyDie(EnemyStats enemyStats)
        {
            enemyStats.Dies -= EnemyDie;
            _allEnemy.Remove(enemyStats.GetComponent<EnemyTrigger>());
            EnemyDies?.Invoke(enemyStats.GetComponent<EnemyTrigger>());
        }

        public void SpawnBoss(GameObject boss, Transform transform)
        {
            GameObject enemy = Instantiate(_enemyPrebuf, transform.position, Quaternion.identity);
            enemy.transform.SetParent(transform, false);
            enemy.GetComponent<EnemyStats>().Init(_playerStats);
            EnemyTrigger enemyTrigger = enemy.GetComponent<EnemyTrigger>();
            _allEnemy.Add(enemyTrigger);
            SpawmEnemy?.Invoke(enemyTrigger);
            enemyTrigger.GetComponent<EnemyStats>().Dies += EnemyDie;
        }
    }
}
