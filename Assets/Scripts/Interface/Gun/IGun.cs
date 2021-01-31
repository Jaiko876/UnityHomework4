using UnityEngine;

namespace Interface.Gun
{
    public interface IGun
    {
        void Shoot();
        void CalculateNextShoot();
    }
}