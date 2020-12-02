using System;
using Controller;
using UnityEngine;

namespace Interactive
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        protected float _speedBonus;
        protected PlayerController _playerController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interact();
            }
        }

        protected abstract void Interact();

        protected void DestroyObject()
        {
            Destroy(gameObject);
        }
        
        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }
    }
}
