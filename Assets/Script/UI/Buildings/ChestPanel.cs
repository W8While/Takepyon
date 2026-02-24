using Game.Building;
using Game.Item;
using Game.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _description;

    public BuildingsManager _buildingsManager;
    private ItemBase _item;


    public void Open(ItemBase item, BuildingsManager buildingsManager)
    {
        gameObject.SetActive(true);
        _buildingsManager = buildingsManager;
        _item = item;
        _image.sprite = _item.ItemScriptibleObjects.ObjectsSprite;
        _description.text = _item.ItemScriptibleObjects.ObjectsDiscription;
    }

    public void OnChose()
    {
        _buildingsManager.OnChestChose(_item);
        gameObject.SetActive(false);
    }

    public void OnSkip()
    {
        _buildingsManager.OnChestSkip();
        gameObject.SetActive(false);
    }
}
