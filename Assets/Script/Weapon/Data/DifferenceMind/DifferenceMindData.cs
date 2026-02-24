using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "DifferenceMind", menuName = "New Skill/DifferenceMind")]
    public class DifferenceMindData : ObjectsScriptibleObjects
    {
        [SerializeField] private float _raduis;
        public float Radius => _raduis;
        [SerializeField] private Aspect _aspect;
        public Aspect Aspect => _aspect;
    }
}
