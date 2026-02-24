using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "ChaosOfRandom", menuName = "New Skill/ChaosOfRandom")]
    public class ChaosOfRandomData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
    }
}