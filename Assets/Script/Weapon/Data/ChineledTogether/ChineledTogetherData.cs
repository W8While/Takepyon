using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "ChineledTogether", menuName = "New Skill/ChineledTogether")]
    public class ChineledTogetherData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _coolDawn;
        public float CoolDawn => _coolDawn;
    }
}