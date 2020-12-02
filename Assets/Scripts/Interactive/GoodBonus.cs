using System;
using Controller;

namespace Interactive
{
    public class GoodBonus : InteractiveObject
    {
        private float _speedBonus;
        public PlayerController _playerController;

        protected override void Interact()
        {
            _speedBonus = 3f;
            _playerController.BonusEnter(_speedBonus);
            DestroyObject();
        }

        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }
    }
}
