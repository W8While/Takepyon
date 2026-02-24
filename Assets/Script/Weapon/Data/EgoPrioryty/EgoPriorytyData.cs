using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "EgoPrioryty", menuName = "New Skill/EgoPrioryty")]
    public class EgoPriorytyData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private int _maxEnemy;
        public int MaxEnemy => _maxEnemy;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}
