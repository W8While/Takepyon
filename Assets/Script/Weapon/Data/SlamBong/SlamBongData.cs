using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "SlamBong", menuName = "New Skill/SlamBong")]
    public class SlamBongData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
    }
}
