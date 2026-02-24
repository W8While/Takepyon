using Game.Item;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Building.Ui.Box
{
    public class BoxItem : MonoBehaviour
    {
        private ItemBase _item;
        private Image _image;
        [SerializeField] private TMP_Text _count;
        private BoxPanel _panel;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _panel = GetComponentInParent<BoxPanel>();
            Exit();
        }

        public void Init(ItemBase item, int count)
        {
            gameObject.SetActive(true);
            _item = item;
            _image.sprite = _item.ItemScriptibleObjects.ObjectsSprite;
            _count.text = count.ToString();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
        }

        public void OnClick()
        {
            _panel.ChouseItem(_item);
        }
    }
}
