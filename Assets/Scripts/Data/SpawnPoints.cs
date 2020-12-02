using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu (menuName = "SpawnPoints")]
    public sealed class SpawnPoints : ScriptableObject
    {
        public List<Transform> spawnPointPositions;
    }
}
