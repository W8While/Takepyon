using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "MidDiff", menuName = "New Skill/MidDiff")]
    public class MidDiffData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private int _maxEnemy;
        public int MaxEnemy => _maxEnemy;
        [SerializeField] private float _valueDifference;
        public float ValueDifference => _valueDifference;
    }
}
