using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(fileName = "newObject", menuName = "NewObject")]
    public class ObjectsScriptibleObjects : ScriptableObject
    {
        [SerializeField] protected Sprite _objectsSprite;
        public Sprite ObjectsSprite => _objectsSprite;
        [SerializeField] protected string _objectsName;
        public string ObjectsName => _objectsName;
        [SerializeField] protected string _objectsDiscription;
        public string ObjectsDiscription => _objectsDiscription;

        private void OnEnable()
        {
            _objectsDiscription = name + " DESCTIPTION";
            _objectsName = name + " NAME";
        }
    }
}
