using System;
using UnityEngine;

namespace Interactive
{
    public abstract class InteractiveObject : MonoBehaviour
    {
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
    }
}
