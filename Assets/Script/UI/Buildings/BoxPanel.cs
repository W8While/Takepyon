using Game.Item;
using Game.Player;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Building.Ui.Box
{
    public class BoxPanel : MonoBehaviour
    {

        [SerializeField] private Image _firstItem;
        private ItemBase _firstItemBase;
        [SerializeField] private Image _secondItem;
        private ItemBase _secondItemBase;

        [SerializeField] private List<BoxItem> _items;
        public BuildingsManager _buildingsManager;

        public void Open(PlayerSkill playerSkill, BuildingsManager buildingsManager)
        {
            gameObject.SetActive(true);
            _buildingsManager = buildingsManager;
            for (int i = 0; i < playerSkill.AvailibleItems.Count; i++)
                _items[i].Init(playerSkill.AvailibleItems[i], playerSkill.AvailibleItems[i].Amount);
        }

        public void Exit()
        {
            _buildingsManager.ExitBoxPanel();
            foreach (BoxItem boxItem in _items)
                boxItem.Exit();
            _firstItemBase = null;
            _secondItemBase = null;
            _firstItem.sprite = null;
            _secondItem.sprite = null;
            gameObject.SetActive(false);
        }

        public void ChouseItem(ItemBase item)
        {
            if (_firstItemBase == null)
            {
                _firstItemBase = item;
                _firstItem.sprite = item.ItemScriptibleObjects.ObjectsSprite;
                return;
            }
            _secondItemBase = item;
            _secondItem.sprite = item.ItemScriptibleObjects.ObjectsSprite;
            _buildingsManager.ReworkItem(_firstItemBase, _secondItemBase);
            Exit();
        }
    }
}
