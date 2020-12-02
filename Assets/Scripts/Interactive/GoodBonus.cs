﻿namespace Interactive
{
    public class GoodBonus : InteractiveObject
    {
        protected override void Interact()
        {
            _speedBonus = 3f;
            _playerController.BonusEnter(_speedBonus);
            DestroyObject();
        }
    }
}
