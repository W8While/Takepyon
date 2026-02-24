using Game.Player;
using Game.Weapon;
using UnityEngine;

namespace Game.Item
{
    public abstract class ItemBase : MonoBehaviour
    {
        [SerializeField] private ObjectsScriptibleObjects _itemScriptibleObjects;
        public ObjectsScriptibleObjects ItemScriptibleObjects => _itemScriptibleObjects;
        [SerializeField] private Rarity _rariry;
        public Rarity Rarity => _rariry;

        public abstract void Init(PlayerStats playerStats);
        protected int _amount;
        public int Amount => _amount;

        public void Remove()
        {
            if (_amount == 0)
                return;
            if (_amount >= 2)
                _amount--;
            if (_amount == 1)
            {
                _amount = 0;
                DisableItem();
            }
        }

        protected abstract void DisableItem();
    }
}


public enum Rarity { Common, Rare}
