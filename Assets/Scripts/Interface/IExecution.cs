using UnityEngine;

namespace Interface
{
    public interface IExecution : IController
    {
        void Execute(float deltaTime);
    }
}
