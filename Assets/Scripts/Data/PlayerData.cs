using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player")]
    public sealed class PlayerData : ScriptableObject
    {
        public float _speed;
        public GameObject player;
    }
}
