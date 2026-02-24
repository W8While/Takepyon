using Game.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Building.Ui
{
    public class LionChouse : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;

        private ObjectsScriptibleObjects _objectsScriptibleObjects;
        private LionPanel _buildingsPanel;

        public void Init(ObjectsScriptibleObjects objectsScriptibleObjects, LionPanel buildingsPanel)
        {
            _objectsScriptibleObjects = objectsScriptibleObjects;
            _buildingsPanel = buildingsPanel;

            _image.sprite = _objectsScriptibleObjects.ObjectsSprite;
            _name.text = _objectsScriptibleObjects.ObjectsName;
            _description.text = _objectsScriptibleObjects.ObjectsDiscription;
        }

        public void Choise()
        {
            _buildingsPanel.OnChose(_objectsScriptibleObjects);
        }
    }
}
