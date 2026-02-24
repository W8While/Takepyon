using UnityEngine;

namespace Game.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Create New Enemy")]
    public class EnemyStatsSctiptibleObjects : ScriptableObject
    {
        [SerializeField] private string _enemyName;
        public string EnemyName => _enemyName;
        [SerializeField] private float _healtPoint;
        public float HealtPoint => _healtPoint;
    }
}
