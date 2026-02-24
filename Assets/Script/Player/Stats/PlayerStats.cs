using Game.Enemy;
using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerScriptibleObjects _playerData;

        private float _maxHealtPoint;
        public float MaxHealtPoint => _maxHealtPoint;
        private float _currentHealtPoint;
        public float CurrentHealtPoint => _currentHealtPoint;
        private float _maxAmaterasu;
        public float MaxAmaterasu => _maxAmaterasu;
        private float _currentAmaterasu;
        public float CurrentAmaterasu => _currentAmaterasu;
        private float _maxTsukyomy;
        public float MaxTsukyomy => _maxTsukyomy;
        private float _currentTsukyomy;
        public float CurrentTsukyomy => _currentTsukyomy;
        private float _maxYokay;
        public float MaxYokay => _maxYokay;
        private float _currentYokay;
        public float CurrentYokay => _currentYokay;

        public Action StatsChange;
        public Action<Aspect> AspectChange;
        public Action<float> GetDamage;
        public Action<int> GetDamageSomeEnemy;
        private int _enemyCount;

        private PlayerSkill _playerSkill;

        private void Awake()
        {
            _playerSkill = GetComponent<PlayerSkill>();
        }

        private void Start()
        {
            _currentHealtPoint = _playerData.MaxHealtPoint;
            _currentAmaterasu = _playerData.StartAmaterasu;
            _currentTsukyomy = _playerData.StartTsukyomu;
            _currentYokay = _playerData.StartYokay;
            _maxHealtPoint = _playerData.MaxHealtPoint;
            _maxAmaterasu = _playerData.MaxAmaterasu;
            _maxTsukyomy = _playerData.MaxTsukyomu;
            _maxYokay = _playerData.MaxYokay;
            StatsChange?.Invoke();
        }

        public void AmaterasuChange(float value)
        {
            _currentAmaterasu = value;
            AspectChange?.Invoke(Aspect.Amaterasu);
            StatsChange?.Invoke();
        }
        public void TsukyomyChange(float value)
        {
            _currentTsukyomy = value;
            AspectChange?.Invoke(Aspect.Tsukyomu);
            StatsChange?.Invoke();
        }
        public void YokayChange(float value)
        {
            _currentYokay = value;
            AspectChange?.Invoke(Aspect.Yokay);
            StatsChange?.Invoke();
        }

        public float GetAspectValue(Aspect aspect)
        {
            switch (aspect)
            {
                case Aspect.Amaterasu:
                    return _currentAmaterasu;
                case Aspect.Tsukyomu:
                    return _currentTsukyomy;
                case Aspect.Yokay:
                    return _currentYokay;
                default:
                    return 0;
            }
        }

        public void GetDamageEnemy(EnemyTrigger enemyTrigger)
        {
            _enemyCount++;
            float damage = _playerSkill.CalculateDamage();
            Debug.Log("Нанес " + damage + " урона");
            enemyTrigger.GetEnemyStats().GetDamage(damage);
            GetDamage?.Invoke(damage);
            GetDamageSomeEnemy?.Invoke(_enemyCount);
        }

        public void TakeDamage(float damage)
        {
            _currentHealtPoint -= damage;
            StatsChange?.Invoke();
            if (_currentHealtPoint <= 0)
                Dies();
        }

        private void Dies()
        {
            Debug.Log("Dies");
        }

        private void LateUpdate()
        {
            _enemyCount = 0;
        }
    }
}
