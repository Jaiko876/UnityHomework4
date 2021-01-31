using Enum;
using UnityEngine;

namespace SpawnPoints
{
    public class BonusSpawnPoint : MonoBehaviour
    {
        [SerializeField] private BonusEnum _type;
        private Vector3 _position;

        public BonusEnum Type
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