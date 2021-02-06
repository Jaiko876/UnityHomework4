using Enum;
using UnityEngine;

namespace SpawnPoints
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyTypeEnum _type;
        private Vector3 _position;

        public EnemyTypeEnum Type
        {
            get => _type;
            set => _type = value;
        }

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }
    }
}