using UnityEngine;

public class AudioPlayer : IAudioPlayer
{
    public void PlayClipAtPoint(AudioClip clip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }
}
