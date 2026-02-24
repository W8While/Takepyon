using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "LittleBustard", menuName = "New Skill/LittleBustard")]
    public class LittleBustardData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _raduis;
        public float Radius => _raduis;
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private float _minClamp;
        public float MinClamp => _minClamp;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}