using System.Collections.Generic;
using Enum;
using SpawnPoints;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class SpawnPointData : ScriptableObject
    {
        public List<SpawnPoint> _spawnPoints;

        public List<SpawnPoint> SpawnPoints
        {
            get => _spawnPoints;
            set => _spawnPoints = value;
        }
    }
}
