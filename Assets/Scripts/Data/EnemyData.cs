using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public GameObject _commonEnemy;
        public float _radiusOfView;
        public float _viewAngle;
        public float _rateOfFire;
        public int _amountOfAmmo;
    }
}
