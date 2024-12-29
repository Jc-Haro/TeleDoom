using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivityX = 500f;
    public float sensitivityY= 500f;
    public float xRotation = 0f;
    public float yRotation = 0f;

    public Transform orientation;

    //Clamp is the value where the rotation stops so the player doesnt snap his fucking neck
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        //The cursor locks on the middle of the screen and it becomes invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sensitivityX = PlayerPrefs.GetFloat("VerticalSensivility");
        sensitivityY = PlayerPrefs.GetFloat("HorizontalSensivility");
    }

    void Update()
    {
        //We get the input from the mouse movement in both X and Y axis
        float mouseX = InputManager.instance.CameraX * sensitivityX * Time.deltaTime;
        float mouseY = InputManager.instance.CameraY * sensitivityY * Time.deltaTime;

        //Rotation on y axis (left and right)
        yRotation += mouseX;
        //Rotation on x axis (up and down)
        xRotation -= mouseY;
        //Clamp
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //We apply the rotation to our transform component
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
