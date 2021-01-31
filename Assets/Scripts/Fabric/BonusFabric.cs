using Data;
using UnityEngine;

namespace Fabric
{
    public class BonusFabric : AbstractFabric <BonusEnum>
    {
        private BonusData _bonusData;

        public BonusFabric(BonusData bonusData)
        {
            _bonusData = bonusData;
        }

        public override GameObject Instantiate(BonusEnum e, Vector3 position, Quaternion quaternion)
        {
            GameObject bonus = null;
            if (BonusEnum.SPEED_BUF == e)
            {
                bonus = GameObject.Instantiate(_bonusData.goodBonus, position, quaternion);
            } 
            else if (BonusEnum.SPEED_DEBUF == e)
            {
                bonus = GameObject.Instantiate(_bonusData.badBonus, position, quaternion);
            }

            return bonus;
        }
    }
}
