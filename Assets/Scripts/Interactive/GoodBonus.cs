using Data;

namespace Interactive
{
    public class GoodBonus : InteractiveObject<BonusData>
    {
        protected override void Interact()
        {
            foreach (var controller in _controllers)
            {
                controller.Interact(_data.speedBonus);
            }
            DestroyObject();
        }
    }
}
