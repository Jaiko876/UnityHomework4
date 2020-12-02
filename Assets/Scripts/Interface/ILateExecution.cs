namespace Interface
{
    public interface ILateExecution : IController
    {
        void LateExecute(float deltaTime);
    }
}
