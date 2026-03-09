using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip hitSound;
    public AudioClip deathSound; 
    public AudioClip wallHitSound;


    public float hitSoundVolume = 0.8f;
    public float deathSoundVolume = 1.0f;
    public float wallHitSoundVolume = 1.5f;


    public void Subscribe(GameObject ball)
    {
        ball.GetComponent<WeaponHealth>().OnHit += HandleHit;
        ball.GetComponent<WeaponHealth>().OnDeath += HandleDeath;
        ball.GetComponent<Ball>().OnHitWall += HandleHitWall;
    }

    public void HandleHit(Vector2 position)
    {
        AudioSource.PlayClipAtPoint(hitSound, position, hitSoundVolume);
    }

    public void HandleDeath(Vector2 position)
    {
        AudioSource.PlayClipAtPoint(deathSound, position, deathSoundVolume);

    }

    public void HandleHitWall(Vector2 position)
    {
        AudioSource.PlayClipAtPoint(wallHitSound, position, wallHitSoundVolume);
    }

}
