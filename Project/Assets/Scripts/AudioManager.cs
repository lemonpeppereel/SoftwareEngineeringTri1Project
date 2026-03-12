using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip hitSound;
    public AudioClip deathSound; 
    public AudioClip wallHitSound;


    public float hitSoundVolume = 0.8f;
    public float deathSoundVolume = 1.0f;
    public float wallHitSoundVolume = 1.5f;

    public IAudioPlayer audioPlayer {get; set;} = new AudioPlayer();

    public void SubscribeForWeaponHealth(WeaponHealth weaponHealth)
    {
        weaponHealth.OnHit += HandleHit; 
        weaponHealth.OnDeath += HandleDeath;
        
    }
    public void SubscribeForBall(Ball ball)
    {
        ball.OnHitWall += HandleHitWall;
    }

    public void HandleHit(Vector2 position)
    {
        audioPlayer.PlayClipAtPoint(hitSound, position, hitSoundVolume);
    }

    public void HandleDeath(Vector2 position)
    {
        audioPlayer.PlayClipAtPoint(deathSound, position, deathSoundVolume);

    }

    public void HandleHitWall(Vector2 position)
    {
        audioPlayer.PlayClipAtPoint(wallHitSound, position, wallHitSoundVolume);
    }

}
