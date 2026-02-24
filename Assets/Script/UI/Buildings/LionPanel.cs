using Game.Weapon;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Building.Ui
{
    public class LionPanel : MonoBehaviour
    {
        [SerializeField] private LionChouse _buildingsChouse;
        [SerializeField] private LionChouse _buildingsChouse2;
        [SerializeField] private LionChouse _buildingsChouse3;

        private BuildingsManager _buildingsManager;

        public void Open(ObjectsScriptibleObjects[] objectsScriptibleObjects, BuildingsManager buildingsManager)
        {
            gameObject.SetActive(true);
            _buildingsManager = buildingsManager;

            _buildingsChouse.Init(objectsScriptibleObjects[0], this);
            _buildingsChouse2.Init(objectsScriptibleObjects[1], this);
            _buildingsChouse3.Init(objectsScriptibleObjects[2], this);
        }

        public void OnChose(ObjectsScriptibleObjects objectsScriptibleObjects)
        {
            _buildingsManager.OnLionChose(objectsScriptibleObjects);
            gameObject.SetActive(false);
        }
    }
}
