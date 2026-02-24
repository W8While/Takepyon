using UnityEngine;

namespace Game.Building.Upgrade
{
    public class UpgradeTrigger : BuildingsTrigger
    {
        protected override void Open()
        {
            _buildingsManager.OpenUpgradeItemPanel();
        }
    }
}
