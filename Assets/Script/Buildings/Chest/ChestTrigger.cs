using UnityEngine;

namespace Game.Building.Chest
{
    public class ChestTrigger : BuildingsTrigger
    {
        protected override void Open()
        {
            _buildingsManager.OpenChestPanel();
        }
    }
}
