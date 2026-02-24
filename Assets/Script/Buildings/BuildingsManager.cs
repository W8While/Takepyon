using Game.Building.Ui;
using Game.Building.Ui.Box;
using Game.Building.Ui.Upgrade;
using Game.Damage;
using Game.Enemy;
using Game.Enemy.Building.Boss;
using Game.Item;
using Game.Player;
using Game.Weapon;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Building
{
    public class BuildingsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _lionStatue;
        [SerializeField] private int _lionStatueCount;
        [SerializeField] private GameObject _chest;
        [SerializeField] private int _chestCount;
        [SerializeField] private GameObject _boxStatue;
        [SerializeField] private int _boxCount;
        [SerializeField] private GameObject _upgradeStatue;
        [SerializeField] private int _upgradeCount;
        [SerializeField] private List<GameObject> _enemyBossStatue;

        [SerializeField] private Terrain _terrain;
        [SerializeField] private PlayerInterection _playerInterection;
        [SerializeField] private PlayerSkill _playerSkill;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private EnemySpawn _enemySpawn;

        private List<WeaponBase> _allWeapons;
        private List<DamageBuffBase> _allDamageBuff;
        private List<ItemBase> _allItems;

        [SerializeField] private Transform _weaponObj;
        [SerializeField] private Transform _damageBuffObj;
        [SerializeField] private Transform _itemObj;

        [SerializeField] private LionPanel _lionPanel;
        [SerializeField] private ChestPanel _chestPanel;
        [SerializeField] private BoxPanel _boxPanel;
        [SerializeField] private UpgradeItemPanel _upgradeItemPanel;

        private void Awake()
        {
            for (int i = 0; i < _lionStatueCount; i++)
            {
                float x = UnityEngine.Random.Range(_terrain.GetPosition().x+50, _terrain.GetPosition().x + _terrain.terrainData.size.x-50);
                float z = UnityEngine.Random.Range(_terrain.GetPosition().z+50, _terrain.GetPosition().z + _terrain.terrainData.size.z-50);
                float y = _terrain.SampleHeight(new Vector3(x, 0, z));
                y += 1;
                SpawnBuiling(new Vector3(x, y, z), _lionStatue);
            }
            for (int i = 0; i < _chestCount; i++)
            {
                float x = UnityEngine.Random.Range(_terrain.GetPosition().x + 50, _terrain.GetPosition().x + _terrain.terrainData.size.x - 50);
                float z = UnityEngine.Random.Range(_terrain.GetPosition().z + 50, _terrain.GetPosition().z + _terrain.terrainData.size.z - 50);
                float y = _terrain.SampleHeight(new Vector3(x, 0, z));
                y += 1;
                SpawnBuiling(new Vector3(x, y, z), _chest);
            }
            for (int i = 0; i < _boxCount; i++)
            {
                float x = UnityEngine.Random.Range(_terrain.GetPosition().x + 50, _terrain.GetPosition().x + _terrain.terrainData.size.x - 50);
                float z = UnityEngine.Random.Range(_terrain.GetPosition().z + 50, _terrain.GetPosition().z + _terrain.terrainData.size.z - 50);
                float y = _terrain.SampleHeight(new Vector3(x, 0, z));
                y += 1;
                SpawnBuiling(new Vector3(x, y, z), _boxStatue);
            }
            for (int i = 0; i < _upgradeCount; i++)
            {
                float x = UnityEngine.Random.Range(_terrain.GetPosition().x + 50, _terrain.GetPosition().x + _terrain.terrainData.size.x - 50);
                float z = UnityEngine.Random.Range(_terrain.GetPosition().z + 50, _terrain.GetPosition().z + _terrain.terrainData.size.z - 50);
                float y = _terrain.SampleHeight(new Vector3(x, 0, z));
                y += 1;
                SpawnBuiling(new Vector3(x, y, z), _upgradeStatue);
            }
            foreach (GameObject go in _enemyBossStatue)
            {
                float x = UnityEngine.Random.Range(_terrain.GetPosition().x + 50, _terrain.GetPosition().x + _terrain.terrainData.size.x - 50);
                float z = UnityEngine.Random.Range(_terrain.GetPosition().z + 50, _terrain.GetPosition().z + _terrain.terrainData.size.z - 50);
                float y = _terrain.SampleHeight(new Vector3(x, 0, z));
                y += 1;
                SpawnBuiling(new Vector3(x, y, z), go);
            }

            _allWeapons = _weaponObj.GetComponents<WeaponBase>().ToList<WeaponBase>();
            _allDamageBuff = _damageBuffObj.GetComponents<DamageBuffBase>().ToList<DamageBuffBase>();
            _allItems = _itemObj.GetComponents<ItemBase>().ToList<ItemBase>();
        }

        private void SpawnBuiling(Vector3 position, GameObject gameObject)
        {
            GameObject go = Instantiate(gameObject, position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.GetComponent<BuildingsTrigger>().Init(this, _enemySpawn);
        }

        public void OpenLionPanel()
        {
            OnOpenPanel();

            ObjectsScriptibleObjects[] _currentWeapons = new ObjectsScriptibleObjects[3];
            _currentWeapons[0] = (_allWeapons[UnityEngine.Random.Range(0, _allWeapons.Count)]).WeaponScriptibleObjects;
            _currentWeapons[1] = (_allDamageBuff[UnityEngine.Random.Range(0, _allDamageBuff.Count)]).DamageScriptibleObjects;
            int index = UnityEngine.Random.Range(0, _allWeapons.Count + _allDamageBuff.Count);
            if (index < _allWeapons.Count)
                _currentWeapons[2] = _allWeapons[index].WeaponScriptibleObjects;
            else
                _currentWeapons[2] = _allDamageBuff[index - _allWeapons.Count].DamageScriptibleObjects;
            _lionPanel.Open(_currentWeapons, this);
        }

        public void OnLionChose(ObjectsScriptibleObjects objectsScriptibleObjects)
        {
            OnClosePanel();
            for (int i = 0; i < _allWeapons.Count; i++)
                if (_allWeapons[i].WeaponScriptibleObjects == objectsScriptibleObjects)
                {
                    _playerSkill.AddWeapon(_allWeapons[i]);
                    _allWeapons.Remove(_allWeapons[i]);
                    return;
                }
            for (int i = 0; i < _allDamageBuff.Count; i++)
                if (_allDamageBuff[i].DamageScriptibleObjects == objectsScriptibleObjects)
                {
                    _playerSkill.AddDamageBuff(_allDamageBuff[i]);
                    _allDamageBuff.Remove(_allDamageBuff[i]);
                    return;
                }
        }

        public void OpenChestPanel()
        {
            OnOpenPanel();

            int index = UnityEngine.Random.Range(0, _allItems.Count);
            ItemBase item = _allItems[index];

            _chestPanel.Open(item, this);
        }

        public void OnChestChose(ItemBase item)
        {
            _playerSkill.AddItem(item);
            OnClosePanel();
        }

        public void OnChestSkip()
        {
            OnClosePanel();
        }

        public void ReworkItem(ItemBase _firstItemBase, ItemBase _secondItemBase)
        {
            _playerSkill.RemoveItem(_firstItemBase);
            _playerSkill.RemoveItem(_secondItemBase);
            int index = UnityEngine.Random.Range(0, _allItems.Count);
            ItemBase item = _allItems[index];
            _playerSkill.AddItem(item);
        }
        public void ExitBoxPanel()
        {
            OnClosePanel();
        }

        public void OpenBoxPanel()
        {
            OnOpenPanel();
            _boxPanel.Open(_playerSkill, this);
        }



        public void OpenUpgradeItemPanel()
        {
            OnOpenPanel();
            _upgradeItemPanel.Open(_playerSkill, this);
        }

        public void UpgradeItem()
        {
            List<ItemBase> _allAbailibleCommomItems = new List<ItemBase>();

            foreach (ItemBase item in _playerSkill.AvailibleItems)
                if (item.Rarity == Rarity.Common)
                for (int i = 0; i < item.Amount; i++)
                    _allAbailibleCommomItems.Add(item);
            if (_allAbailibleCommomItems.Count < 3)
            {
                _upgradeItemPanel.Exit();
                return;
            }
            ItemBase[] randomItems = new ItemBase[3];
            for (int i = 0; i < 3; i++)
            {
                randomItems[i] = _allAbailibleCommomItems[UnityEngine.Random.Range(0, _allAbailibleCommomItems.Count)];
                _allAbailibleCommomItems.Remove(randomItems[i]);
                _playerSkill.RemoveItem(randomItems[i]);
            }

            List<ItemBase> _allRareItems = new List<ItemBase>();
            foreach (ItemBase item in _allItems)
                if (item.Rarity == Rarity.Rare)
                    _allRareItems.Add(item);

            ItemBase newItem = _allRareItems[UnityEngine.Random.Range(0, _allRareItems.Count)];
            _playerSkill.AddItem(newItem);

            _upgradeItemPanel.Exit();

        }
        public void ExitUpgradeItemPanel()
        {
            OnClosePanel();
        }

        public void SpawnBoss()
        {
            Debug.Log(3);
            OnClosePanel();
        }



        private void OnOpenPanel()
        {
            Time.timeScale = 0f;
        }
        private void OnClosePanel()
        {
            Debug.Log(6);
            Time.timeScale = 1f;
            _playerInterection.ExitPanel();
        }
    }
}
