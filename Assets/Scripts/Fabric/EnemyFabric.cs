using Controller;
using Data;
using Enum;
using UnityEngine;
using View;

namespace Fabric
{
    public class EnemyFabric : AbstractFabric <EnemyTypeEnum>
    {
        private EnemyData _enemyData;

        public EnemyFabric(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }
        
        public override GameObject Instantiate(EnemyTypeEnum e, Vector3 position, Quaternion quaternion)
        {
            GameObject enemy = null;
            if (e == EnemyTypeEnum.COMMON)
            {
                enemy = GameObject.Instantiate(_enemyData._commonEnemy, position, quaternion);
                
            }
            return enemy;
        }
    }
}