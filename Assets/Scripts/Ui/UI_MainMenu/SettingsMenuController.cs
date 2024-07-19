using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject Game;

    public GameObject Keyboard;

    public GameObject Controller;

    public GameObject Controls;

    public void SystemControl(GameObject Ob1, GameObject Ob2, GameObject Ob3, GameObject Ob4){
        Ob1.SetActive(true);
        Ob2.SetActive(false);  
        Ob3.SetActive(false);
        Ob4.SetActive(false);       
    }

    public void GameControl(){
        SystemControl(Game, Keyboard, Controller, Controls);
    }

    public void KeyboardControl(){
        SystemControl(Keyboard, Controller, Controls, Game);
    }

    public void ControllerControl(){
        SystemControl(Controller, Controls, Game, Keyboard);
    }

    public void ControlsControl(){
        SystemControl(Controls, Game, Keyboard, Controller);
    }
}
