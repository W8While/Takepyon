using System.Collections.Generic;
using UnityEngine;
using Game.Weapon;
using Game.Damage;
using TMPro;
using Game.Item;

namespace Game.Player {
    public class PlayerSkill : MonoBehaviour
    {
        private List<WeaponBase> _availibleWeapons = new List<WeaponBase>();
        public List<WeaponBase> AvailibleWeapons => _availibleWeapons;
        private List<DamageBuffBase> _availibleDamageBuff = new List<DamageBuffBase>();
        public List<DamageBuffBase> AvailibleDamageBuff => _availibleDamageBuff;
        private List<ItemBase> _availibleItems = new List<ItemBase>();
        public List<ItemBase> AvailibleItems => _availibleItems;

        private List<IDamageBuffAddWhite> _damageBuffAddWhites = new List<IDamageBuffAddWhite>();
        private List<IDamageBuffAddGreen> _damageBuffAddGreen = new List<IDamageBuffAddGreen>();
        private List<IDamageBuffMultiplay> _damageBuffMultiplay = new List<IDamageBuffMultiplay>();

        [SerializeField] private TMP_Text currentDamageText;

        public void AddWeapon(WeaponBase weapon)
        {
            _availibleWeapons.Add(weapon);
            weapon.enabled = true;
        }

        public void AddDamageBuff(DamageBuffBase damage)
        {
            _availibleDamageBuff.Add(damage);

            if (damage is IDamageBuffAddWhite white)
                _damageBuffAddWhites.Add(white);
            if (damage is IDamageBuffAddGreen green)
                _damageBuffAddGreen.Add(green);
            if (damage is IDamageBuffMultiplay multiplay)
                _damageBuffMultiplay.Add(multiplay);
        }

        public float CalculateDamage()
        {
            float whiteDamage = 0;
            foreach (IDamageBuffAddWhite getWhiteDamage in _damageBuffAddWhites)
                whiteDamage += getWhiteDamage.DamageBuffAddWhite();
            float greenDamage = 0;
            foreach (IDamageBuffAddGreen getGreenDamage in _damageBuffAddGreen)
                greenDamage += getGreenDamage.DamageBuffAddGreen();
            float multiplay = 1;
            foreach (IDamageBuffMultiplay getMultiplay in _damageBuffMultiplay)
                multiplay += (getMultiplay.DamageBuffAddMultiplay());
            if (multiplay == 0)
                multiplay = 1;
            float finalyDamage = whiteDamage * multiplay + greenDamage;
            if (finalyDamage < 0)
                finalyDamage = 0;
            return finalyDamage;
        }

        public void AddItem(ItemBase item)
        {
            item.Init(GetComponent<PlayerStats>());
            foreach (ItemBase itemBase in _availibleItems)
                if (itemBase == item)
                    return;
            _availibleItems.Add(item);
        }
        public void RemoveItem(ItemBase item)
        {
            _availibleItems.Remove(item);
            item.Remove();
        }

        private void Update()
        {
            currentDamageText.text = CalculateDamage().ToString();
        }

    }
}
