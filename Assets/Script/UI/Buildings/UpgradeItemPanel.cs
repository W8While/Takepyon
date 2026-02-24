using Game.Player;
using UnityEngine;

namespace Game.Building.Ui.Upgrade
{
    public class UpgradeItemPanel : MonoBehaviour
    {

        public BuildingsManager _buildingsManager;

        public void Open(PlayerSkill playerSkill, BuildingsManager buildingsManager)
        {
            gameObject.SetActive(true);
            _buildingsManager = buildingsManager;
        }


        public void StartUpgrade()
        {
            _buildingsManager.UpgradeItem();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
            _buildingsManager.ExitUpgradeItemPanel();
        }
    }
}
