using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "NearistRake", menuName = "New Skill/NearistRake")]
    public class NearistRakeData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
    }
}
