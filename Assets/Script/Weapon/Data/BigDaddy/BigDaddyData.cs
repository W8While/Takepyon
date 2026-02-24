using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "BigDaddy", menuName = "New Skill/BigDaddy")]
    public class BigDaddyData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _raduis;
        public float Radius => _raduis;
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private float _maxClamp;
        public float MaxClamp => _maxClamp;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}
