using NUnit.Framework.Internal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject testPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;
        Invoke("Spawn", 1f);
    }

    public void Spawn()
    {
        Instantiate(testPrefab, spawnpoint.position, spawnpoint.rotation);
    }

}
