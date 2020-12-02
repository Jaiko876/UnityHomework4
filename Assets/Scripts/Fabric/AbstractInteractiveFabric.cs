using UnityEngine;

namespace Fabric
{
    public abstract class AbstractInteractiveFabric <T>
    { 
        public abstract GameObject Instantiate(T e, Vector3 position, Quaternion quaternion);
    }
}