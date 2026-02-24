using Game.Player;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Enemy {
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] private EnemyStatsSctiptibleObjects _baseStatsData;

        private float _maxHealtPoint;
        public float MaxHealtPoint => _maxHealtPoint;
        private float _currentHealtPoint;
        public float CurrentHealtPoint => _currentHealtPoint;

        public Action<EnemyStats> Dies;

        public void Init(PlayerStats playerStats)
        {
            _maxHealtPoint = _currentHealtPoint = _baseStatsData.HealtPoint;
            GetComponent<EnemyMove>().Init(playerStats);
        }

        public void GetDamage(float damage)
        {
            Debug.Log("Get " + damage + " damage");
            _currentHealtPoint -= damage;
            if (_currentHealtPoint <= 0)
                Die();
        }

        private void Die()
        {
            Dies?.Invoke(this);
            gameObject.SetActive(false);
            StartCoroutine(DiesAll());
            Debug.Log("Dies");
        }

        private IEnumerator DiesAll()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
