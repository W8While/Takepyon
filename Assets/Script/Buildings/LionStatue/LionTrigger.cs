using UnityEngine;

namespace Game.Building.Lion
{
    public class LionTrigger : BuildingsTrigger
    {
        protected override void Open()
        {
            _buildingsManager.OpenLionPanel();
        }
    }
}
