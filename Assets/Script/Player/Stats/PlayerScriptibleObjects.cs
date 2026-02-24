using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
    public class PlayerScriptibleObjects : ScriptableObject
    {
        [SerializeField] private float _maxHealtPoint;
        public float MaxHealtPoint => _maxHealtPoint;
        [SerializeField] private float _maxAmaterasu;
        public float MaxAmaterasu => _maxAmaterasu;
        [SerializeField] private float _startAmaterasu;
        public float StartAmaterasu => _startAmaterasu;
        [SerializeField] private float _maxTsukuyomu;
        public float MaxTsukyomu => _maxTsukuyomu;
        [SerializeField] private float _startTsukyomu;
        public float StartTsukyomu => _startTsukyomu;
        [SerializeField] private float _maxYokay;
        public float MaxYokay => _maxYokay;
        [SerializeField] private float _startYokay;
        public float StartYokay => _startYokay;
    }
}
