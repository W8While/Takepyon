using UnityEngine;

namespace Game.Building.Box
{
    public class BoxTrigger : BuildingsTrigger
    {
        protected override void Open()
        {
            _buildingsManager.OpenBoxPanel();
        }
    }
}
