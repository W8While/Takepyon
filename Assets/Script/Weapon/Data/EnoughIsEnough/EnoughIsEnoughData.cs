using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "EnoughIsEnough", menuName = "New Skill/EnoughIsEnough")]
    public class EnoughIsEnoughData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private float _value;
        public float Value => _value;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}
