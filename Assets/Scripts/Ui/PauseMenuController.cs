using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{

    public GameObject settings;
    public GameObject pause;
    bool isPaused;

    [SerializeField] GameObject settingsCanvas;

    public Button buttonSettings;
    public Button buttonPause;

    private void Update()
    {
        if (InputManager.instance.Pause)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                buttonPause.Select();
                pause.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume(){
        Time.timeScale = 1f;
        isPaused = false;
        settingsCanvas.SetActive(false);
        pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void SettingsOn(){
        ObjectOnOff(pause, settings, buttonSettings);
	}

    public void SettingsOff(){
        ObjectOnOff(settings, pause, buttonPause);
	}

    public void ObjectOnOff(GameObject obon1, GameObject obon2, Button button){
        obon2.SetActive(true);
        obon1.SetActive(false);
        button.Select();
    }

    public void ObjectOnOffUI(GameObject obon1, GameObject obon2){
        obon2.SetActive(true);
        obon1.SetActive(false);
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
