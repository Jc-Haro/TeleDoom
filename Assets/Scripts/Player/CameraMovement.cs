using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivityX = 500f;
    public float sensitivityY= 500f;
    public float xRotation = 0f;
    public float yRotation = 0f;

    //Clamp is the value where the rotation stops so the player doesnt snap his fucking neck
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        //The cursor locks on the middle of the screen and it becomes invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //We get the input from the mouse movement in both X and Y axis
        float mouseX = InputManager.instance.Camera.x * sensitivityX * Time.deltaTime;
        float mouseY = InputManager.instance.Camera.y * sensitivityY * Time.deltaTime;

        //Rotation on x axis (up and down)
        xRotation -= mouseY;
        //Clamp
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        //Rotation on y axis (left and right)
        yRotation += mouseX;

        //We apply the rotation to our transform component
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
