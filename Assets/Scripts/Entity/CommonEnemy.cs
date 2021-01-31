using Controller;
using Interface;
using Interface.Gun;
using UnityEngine;
using UnityEngine.AI;

namespace Entity
{
    public class CommonEnemy : IAlive
    {
        private GameObject _enemyView;
        private IGun _gun;
        private NavMeshAgent _navMeshAgent;
        private float _health = 15f;

        public NavMeshAgent NavMeshAgent
        {
            get => _navMeshAgent;
            set => _navMeshAgent = value;
        }

        public GameObject EnemyView
        {
            get => _enemyView;
            set => _enemyView = value;
        }

        public IGun Gun
        {
            get => _gun;
            set => _gun = value;
        }

        public float GetHealthPoints()
        {
            return _health;
        }

        public void SetHealthPoints(float healthPoints)
        {
            _health = healthPoints;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
        }

        public bool IsDead()
        {
            return _health <= 0;
        }
    }
}