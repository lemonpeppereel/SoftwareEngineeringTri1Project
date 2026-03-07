using UnityEngine;

public interface IDeathCounter
{
    int  DeathCount { get; }
    void IncrementDeathCounter();
}
