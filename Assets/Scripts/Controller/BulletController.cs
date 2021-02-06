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
        private LinkedList<GameObject> _activeBullets;

        private BulletData _bulletData;
        
        public BulletController(BulletData bulletData)
        {
            _bulletData = bulletData;
            _bullets = new LinkedList<GameObject>();
            _activeBullets = new LinkedList<GameObject>();
        }
        
        public void Execute(float deltaTime)
        {
            Fly();
        }

        public void AddBullet(Transform bulletSpawner)
        {
            if (_bullets.Last != null)
            {
                var gameObject = _bullets.Last.Value;
                _bullets.RemoveLast();
                gameObject.transform.position = bulletSpawner.transform.position;
                gameObject.transform.rotation = bulletSpawner.rotation;
                gameObject.SetActive(true);
                _activeBullets.AddLast(gameObject);
            }
            else
            {
                GameObject bullet =
                    GameObject.Instantiate(_bulletData._bullet, bulletSpawner.position, bulletSpawner.rotation);
                var bulletView = bullet.GetComponent<BulletView>();
                bulletView.SubscribeControllers();
                _activeBullets.AddLast(bullet);
            }
        }

        public void StashBullet(GameObject bullet)
        {
            _activeBullets.Remove(bullet);
            bullet.transform.Translate(Vector3.zero);
            bullet.SetActive(false);
            _bullets.AddLast(bullet);
        }

        public void MakeDamage(IAlive entity)
        {
            entity.TakeDamage(5f);
        }
        
        private void Fly()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.transform.Translate(Vector3.forward * (_bulletData._speed * Time.deltaTime));
            }
        }
    }
}