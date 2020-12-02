using Data;

namespace Interactive
{
    public class BadBonus : InteractiveObject<BonusData>
    {
        protected override void Interact()
        {
            var speedBonus = _data.speedBonus * -1f;
            foreach (var controller in _controllers)
            {
                controller.Interact(speedBonus);
            }
            DestroyObject();
        }
    }
}
