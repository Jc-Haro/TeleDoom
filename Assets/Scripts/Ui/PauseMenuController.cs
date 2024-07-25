using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{

    public GameObject settings;
    public GameObject Pause;

    public Button buttonSettings;
    public Button buttonPause;

    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SettingsOn(){
        ObjectOnOff(Pause, settings, buttonSettings);
	}

    public void SettingsOff(){
        ObjectOnOff(settings, Pause, buttonPause);
	}

     public void ObjectOnOff(GameObject obon1, GameObject obon2, Button button){
        obon2.SetActive(true);
        obon1.SetActive(false);
        button.Select();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        	UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
    }
}
