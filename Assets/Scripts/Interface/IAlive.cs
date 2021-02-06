namespace Interface
{
    public interface IAlive
    {
        float GetHealthPoints();
        void SetHealthPoints(float healthPoints);
        void TakeDamage(float damage);

        bool IsDead();
    }
}