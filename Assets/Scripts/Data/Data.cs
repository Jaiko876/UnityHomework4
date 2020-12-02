using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private BonusData _bonusData;
    
        public PlayerData PlayerData
        {
            get => _playerData;
            set => _playerData = value;
        }

        public CameraData CameraData
        {
            get => _cameraData;
            set => _cameraData = value;
        }

        public BonusData BonusData
        {
            get => _bonusData;
            set => _bonusData = value;
        }
    }
}
