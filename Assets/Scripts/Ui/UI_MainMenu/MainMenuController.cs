using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public Animator CameraObject;

    private void Start()
    {
             
    }
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

    public void ObjectOnOff(GameObject obon1, GameObject obon2){
        obon2.SetActive(true);
        StartCoroutine(TimeAndDelay());
        obon1.SetActive(false);
    }

    public void SettingsOn(){
		CameraObject.SetFloat("Settings 0",1);
        ObjectOnOff(mainMenu, settings);
	}
        
    public void SettingsOff(){
    	CameraObject.SetFloat("Settings 0",0);
        ObjectOnOff(settings, mainMenu);
	}

    public void CreditsOn(){
		CameraObject.SetFloat("Credits 0",1);
        ObjectOnOff(mainMenu, credits);
	}
        
    public void CreditsOff(){
    	CameraObject.SetFloat("Credits 0",0);
        ObjectOnOff(credits, mainMenu);
	}

    private IEnumerator TimeAndDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
