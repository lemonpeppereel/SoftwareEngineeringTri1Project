using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{

    private static DeathCounter _instance;
    public static DeathCounter Instance { get { return _instance; }} 
    public int deathCounter { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI deathCounterText; 

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateDeathCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementDeathCounter()
    {
        deathCounter++;
        UpdateDeathCounter();
        Debug.Log("Weapons destroyed: " + deathCounter); 
    }

    private void UpdateDeathCounter()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = "Weapons killed: " + deathCounter.ToString();
        }
    }
}
