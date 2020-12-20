using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using Interface;
using UnityEngine;

namespace Interactive
{
    public abstract class InteractiveObject<T> : MonoBehaviour where T : ScriptableObject
    {
        protected T _data;
        protected List<ITrigger> _controllers = new List<ITrigger>();
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
        
        public void AddController(ITrigger triggerController)
        {
            if (!_controllers.Any(c => c.Equals(triggerController)))
            {
                _controllers.Add(triggerController);
            }
        }

        public void SetData(T data)
        {
            _data = data;
        }
    }
}
