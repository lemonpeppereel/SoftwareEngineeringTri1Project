using NUnit.Framework; 
using NSubstitute;
using UnityEngine;

[TestFixture]
public class AudioManagerTests
{
    private AudioManager _audioManager;
    private IAudioPlayer _audioPlayer;
    private AudioClip _hitAudio;
    private AudioClip _deathAudio;
    private AudioClip _wallHitAudio;

    [SetUp]
    public void Setup()
    {
        _audioManager = new GameObject().AddComponent<AudioManager>();
        _audioPlayer = Substitute.For<IAudioPlayer>();
        _audioManager.audioPlayer = _audioPlayer;

        _hitAudio = AudioClip.Create("hit", 1, 1, 44100, false);
        _deathAudio = AudioClip.Create("death", 1, 1, 44100, false);
        _wallHitAudio = AudioClip.Create("wallHit", 1, 1, 44100, false);

        _audioManager.hitSound = _hitAudio;
        _audioManager.deathSound = _deathAudio;
        _audioManager.wallHitSound = _wallHitAudio;
    }



    // check if audio plays after something subscribes
    [Test]
    public void SubscribeForWeaponHealth_PlaySoundWhenHit()
    {
        // Arrange
        WeaponHealth weaponHealth = new GameObject().AddComponent<WeaponHealth>();
        _audioManager.SubscribeForWeaponHealth(weaponHealth);
        Vector2 position = new Vector2(1f,1f);

        // Act
        weaponHealth.OnHit?.Invoke(position);

        // Assert
        _audioPlayer.Received(1).PlayClipAtPoint(_hitAudio, new Vector2(1f, 1f), 0.8f);
    }


    [Test]
    public void SubscribeForBall_PlaySoundWhenHit()
    {
        // Arrange
        Ball ball = new GameObject().AddComponent<Ball>();
        _audioManager.SubscribeForBall(ball);
        Vector2 position = new Vector2(1f,1f);

        // Act
        ball.OnHitWall?.Invoke(position);

        // Assert
        _audioPlayer.Received(1).PlayClipAtPoint(_wallHitAudio, new Vector2(1f, 1f), 1.5f);
    }



    // test if correct sounds play for each sound method 
    [Test]
    public void HandleHit_PlaysCorrectSound_WithCorrectPositionAndVolume()
    {
        // Arrange
        Vector2 position = new Vector2(1f,1f);

        // Act
        _audioManager.HandleHit(position);

        //Assert
        _audioPlayer.Received(1).PlayClipAtPoint(_hitAudio, new Vector2(1f, 1f), 0.8f);
    }


    [Test]
    public void HandleDeath_PlaysCorrectSound_WithCorrectPositionAndVolume()
    {
        // Arrange
        Vector2 position = new Vector2(1f,1f);

        // Act
        _audioManager.HandleDeath(position);

        //Assert
        _audioPlayer.Received(1).PlayClipAtPoint(_deathAudio, new Vector2(1f, 1f), 1f);
    }


    [Test]
    public void HandleHitWall_PlaysCorrectSound_WithCorrectPositionAndVolume()
    {
        // Arrange
        Vector2 position = new Vector2(1f,1f);

        // Act
        _audioManager.HandleHitWall(position);

        //Assert
        _audioPlayer.Received(1).PlayClipAtPoint(_wallHitAudio, new Vector2(1f, 1f), 1.5f);
    }
}
