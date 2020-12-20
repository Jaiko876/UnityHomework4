using Enum;
using UnityEngine;

namespace SpawnPoints
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private SpawnPointTypeEnum _type;
        private Vector3 _position;

        public SpawnPointTypeEnum Type
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