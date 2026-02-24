using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "LowPriority", menuName = "New Skill/LowPriority")]
    public class LowPriorityData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private int _maxEnemy;
        public int MaxEnemy => _maxEnemy;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}