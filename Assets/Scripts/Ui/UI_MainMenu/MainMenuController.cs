using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;

    public Button buttonSettings;

    public Button buttonCredits;

    public Button buttonMenu;

    public Button menuLevel;

    public Animator CameraObject;

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        	UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
    }

    public void ObjectOnOff(GameObject obon1, GameObject obon2, Button button){
        obon2.SetActive(true);
        StartCoroutine(TimeAndDelay());
        obon1.SetActive(false);
        button.Select();
    }

    public void SettingsOn(){
		CameraObject.SetFloat("Settings 0",1);
        ObjectOnOff(mainMenu, settings, buttonSettings);
	}
        
    public void SettingsOff(){
    	CameraObject.SetFloat("Settings 0",0);
        ObjectOnOff(settings, mainMenu, buttonMenu);
	}

    public void CreditsOn(){
		CameraObject.SetFloat("Credits 0",1);
        ObjectOnOff(mainMenu, credits, buttonCredits);
	}
        
    public void CreditsOff(){
    	CameraObject.SetFloat("Credits 0",0);
        ObjectOnOff(credits, mainMenu, buttonMenu);
	}

    public void SelectMenu(){
        menuLevel.Select();
    }

    public void SelectMenuMian(){
        buttonMenu.Select();
    }

    private IEnumerator TimeAndDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
