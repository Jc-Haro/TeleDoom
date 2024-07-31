using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public static InputManager instance;

    //Inputs codes
    public Vector2 Movement { get; private set; }
    public float CameraX { get; private set; }
    public float CameraY { get; private set; }
    public bool JumpMantle { get; private set; }
    public bool ShootReactivateTP { get; private set; }
    public bool Shoot { get; private set; }
    public bool AutomaticShoot { get; private set; }
    public bool Pause {  get; private set; }

    //Input actions
    private InputAction movement;
    private InputAction cameraMovementX;
    private InputAction cameraMovementY;
    private InputAction jumpMante;
    private InputAction shootreactivateTP;
    private InputAction shoot;
    private InputAction pause;

    private void Awake()
    {
        if (InputManager.instance == null)
        {
            InputManager.instance = this;
        }
        else
        {
            Destroy(this);
        }

        playerInput = GetComponent<PlayerInput>();

        movement = playerInput.actions["Movement"];
        cameraMovementX = playerInput.actions["CameraX"];
        cameraMovementY = playerInput.actions["CameraY"];
        jumpMante = playerInput.actions["JumpMantle"];
        shootreactivateTP = playerInput.actions["ShootReactivateTP"];
        shoot = playerInput.actions["Shoot"];
        pause = playerInput.actions["Pause"];

    }
    void Update()
    {
        Movement = movement.ReadValue<Vector2>();    
        CameraX = cameraMovementX.ReadValue<float>();
        CameraY = cameraMovementY.ReadValue<float>();
        JumpMantle = jumpMante.WasPressedThisFrame();
        ShootReactivateTP = shootreactivateTP.WasPressedThisFrame();
        Shoot = shoot.WasPressedThisFrame();
        AutomaticShoot = shoot.IsPressed();
        Pause = pause.WasPressedThisFrame();
    }
}
