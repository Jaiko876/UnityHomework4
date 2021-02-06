using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private BonusData _bonusData;
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private SpawnPointData _spawnPointData;
        [SerializeField] private BulletData _bulletData;

        public BulletData BulletData
        {
            get => _bulletData;
            set => _bulletData = value;
        }

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

        public SpawnPointData SpawnPointData
        {
            get => _spawnPointData;
            set => _spawnPointData = value;
        }
        
        public EnemyData EnemyData
        {
            get => _enemyData;
            set => _enemyData = value;
        }
    }
}
