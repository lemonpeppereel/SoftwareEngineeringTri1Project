using UnityEngine;

public class ControlMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame() //starts / resumes
    {
        Time.timeScale = 1f;

    }

    public void QuitGame(){
        Application.Quit(); 
    }

}
