using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "Radiance", menuName = "New Skill/Radiance")]
    public class RadianceData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
        [SerializeField] private float _radius;
        public float Radius => _radius;
    }
}
