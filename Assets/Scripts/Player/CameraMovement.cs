using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;
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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

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