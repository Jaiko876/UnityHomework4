using Controller;
using Interface.Gun;
using UnityEngine;

namespace Weapon
{
    public class CommonGun : IGun
    {
        private BulletController _bulletController;
        private Transform _bulletSpawner;
        private int _amountOfAmmo;
        private float _rateOfFire;

        private float _nextShoot;
        
        public CommonGun(Transform bulletSpawner, int amountOfAmmo, float rateOfFire)
        {
            _bulletSpawner = bulletSpawner;
            _bulletController = (BulletController) ControllerMaster.InjectController(typeof(BulletController));
            _nextShoot = -1f;
            _amountOfAmmo = amountOfAmmo;
            _rateOfFire = rateOfFire;
        }
        
        public void Shoot()
        {
            if (_nextShoot <= 0)
            {
                _bulletController.AddBullet(_bulletSpawner);
                _nextShoot = _rateOfFire;
            }
        }

        public void CalculateNextShoot()
        {
            if (_nextShoot > 0)
            {
                _nextShoot -= Time.deltaTime;
            }
        }
    }
}