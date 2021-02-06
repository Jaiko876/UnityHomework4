using UnityEngine;

namespace Fabric
{
    public abstract class AbstractFabric <T>
    { 
        public abstract GameObject Instantiate(T e, Vector3 position, Quaternion quaternion);
    }
}