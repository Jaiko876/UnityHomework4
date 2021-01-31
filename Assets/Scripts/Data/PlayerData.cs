using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player")]
    public sealed class PlayerData : ScriptableObject
    {
        public float _speed;
        public float health;
        public float _rateOfFire;
        public int _amountOfAmmo;
        public GameObject player;
    }
}
