using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "ChangeMyMind", menuName = "New Skill/ChangeMyMind")]
    public class ChangeMyMindData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _radius;
        public float Radius => _radius;
    }
}