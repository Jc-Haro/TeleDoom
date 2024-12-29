using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOptions : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void Home(string home)
    {
        SceneManager.LoadScene(home);
    }
}
