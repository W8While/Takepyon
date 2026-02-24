using Game.Player;
using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

namespace Game.Enemy {
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _damage;

        private PlayerStats _playerStats;
        private bool _isAttackReady;

        public void Init(PlayerStats playerStats)
        {
            _playerStats = playerStats;
            _isAttackReady = true;
        }

        private void Update()
        {
            if (!gameObject.activeSelf)
                return;
            if (_playerStats == null)
                return;
            if (_isAttackReady)
            {
                if (Vector3.Magnitude(transform.position - _playerStats.transform.position) <= _attackRange)
                {
                    Attack();
                    return;
                }
            }
            Vector3 position = new Vector3(_playerStats.transform.position.x, transform.position.y, _playerStats.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, position, _moveSpeed * Time.deltaTime);
            transform.LookAt(position);
        }

        private void Attack()
        {
            _playerStats.TakeDamage(_damage);
            _isAttackReady = false;
            StartCoroutine(ReloadAttack());
        }

        private IEnumerator ReloadAttack()
        {
            yield return new WaitForSeconds(_attackSpeed);
            _isAttackReady = true;
            yield break;
        }
    }
}
