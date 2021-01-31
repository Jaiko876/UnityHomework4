using System.Collections.Generic;
using Data;
using Interface;
using UnityEditor;
using UnityEngine;
using View;

namespace Controller
{
    public class BulletController : IExecution
    {
        
        private LinkedList<GameObject> _bullets;

        private BulletData _bulletData;
        
        public BulletController(BulletData bulletData)
        {
            _bulletData = bulletData;
            _bullets = new LinkedList<GameObject>();
        }
        
        public void Execute(float deltaTime)
        {
            Fly();
        }

        public void AddBullet(Transform bulletSpawner)
        {
            GameObject bullet =
                GameObject.Instantiate(_bulletData._bullet, bulletSpawner.position, bulletSpawner.rotation);
            var bulletView = bullet.GetComponent<BulletView>();
            bulletView.SubscribeControllers();
            _bullets.AddLast(bullet);
        }

        public void DeleteBullet(GameObject bullet)
        {
            _bullets.Remove(bullet);
        }

        public void MakeDamage(IAlive entity)
        {
            entity.TakeDamage(5f);
        }
        
        private void Fly()
        {
            foreach (var bullet in _bullets)
            {
                bullet.transform.Translate(Vector3.forward * (_bulletData._speed * Time.deltaTime));
            }
        }
    }
}