using System;
using System.Collections.Generic;
using Controller;
using Interface;
using Player;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        private BulletController _bulletController;
        private EnemyController _enemyController;
        private PlayerController _playerController;
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Bullet"))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    _playerController.PlayerActionService.TakeDamage(5f);
                }

                if (other.gameObject.CompareTag("Enemy"))
                {
                    var commonEnemy = _enemyController.Enemies.Find((enemy => enemy.EnemyView == other.gameObject));
                    commonEnemy.TakeDamage(5f);
                }
                _bulletController.StashBullet(gameObject);
            }
        }

        public void SubscribeControllers()
        {
            _bulletController = (BulletController) ControllerMaster.InjectController(typeof(BulletController));
            _enemyController = (EnemyController) ControllerMaster.InjectController(typeof(EnemyController));
            _playerController = (PlayerController) ControllerMaster.InjectController(typeof(PlayerController));
        }
        
    }
}