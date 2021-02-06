using System.Collections.Generic;
using Enum;
using SpawnPoints;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class SpawnPointData : ScriptableObject
    {
        public List<BonusSpawnPoint> _bonusBonusSpawnPoints;
        public List<EnemySpawnPoint> _enemySpawnPoints;

        public List<EnemySpawnPoint> EnemySpawnPoints
        {
            get => _enemySpawnPoints;
            set => _enemySpawnPoints = value;
        }

        public List<BonusSpawnPoint> BonusSpawnPoints
        {
            get => _bonusBonusSpawnPoints;
            set => _bonusBonusSpawnPoints = value;
        }
    }
}
