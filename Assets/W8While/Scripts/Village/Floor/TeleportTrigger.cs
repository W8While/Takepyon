using Game.Koko;
using UnityEngine;

namespace Game.Village
{
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private TeleportTrigger _teleportTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MoveController moveController))
            {
                Vector3 worldPointPosition = other.transform.position;
                worldPointPosition = transform.InverseTransformPoint(worldPointPosition);
                _teleportTrigger?.TeleportThisPoint(moveController, worldPointPosition, transform.eulerAngles.y);
            }
        }

        public void TeleportThisPoint(MoveController moveController, Vector3 point, float yRotation)
        {
            Vector3 pos = transform.TransformVector(point);
            Vector3 newPos = transform.position + pos;
            float yDiffirence = transform.eulerAngles.y - yRotation;
            moveController.TeleportToPoint(newPos, yDiffirence);
        }
    }
}
