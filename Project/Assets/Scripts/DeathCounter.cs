public class DeathCounter : IDeathCounter
{
    public int DeathCount { get; private set; } = 0;

    public void IncrementDeathCounter()
    {
        DeathCount++;
    }
}