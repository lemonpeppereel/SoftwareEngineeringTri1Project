using UnityEngine;

public interface IAudioPlayer
{
    void PlayClipAtPoint(AudioClip clip, Vector2 position, float volume);
}
