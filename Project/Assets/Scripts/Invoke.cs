using NUnit.Framework.Internal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public GameObject testPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", 1f);
    }

    public void Spawn()
    {
        Instantiate(testPrefab);
    }

}
