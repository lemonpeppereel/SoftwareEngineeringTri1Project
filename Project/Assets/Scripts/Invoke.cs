using NUnit.Framework.Internal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject weaponPrefab;
    public AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        GameObject ball = Instantiate(weaponPrefab, spawnpoint.position, spawnpoint.rotation);
        audioManager.Subscribe(ball);
    }

}
