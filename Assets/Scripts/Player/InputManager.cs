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
    public Vector2 Camera { get; private set; }
    public bool Jump { get; private set; }
    public bool Mantle { get; private set; }
    public bool ShootReactivateTP { get; private set; }
    public bool Shoot { get; private set; }

    //Input actions
    private InputAction movement;
    private InputAction cameraMovement;
    private InputAction jump;
    private InputAction mantle;
    private InputAction shootreactivateTP;
    private InputAction shoot;

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
        cameraMovement = playerInput.actions["Camera"];
        jump = playerInput.actions["Jump"];
        mantle = playerInput.actions["Mantle"];
        shootreactivateTP = playerInput.actions["ShootReactivateTP"];
        shoot = playerInput.actions["Shoot"];
    }
    void Update()
    {
        Movement = movement.ReadValue<Vector2>();    
        Camera = cameraMovement.ReadValue<Vector2>();
        Jump = jump.WasPressedThisFrame();
        Mantle = mantle.WasPressedThisFrame();
        ShootReactivateTP = shootreactivateTP.WasPressedThisFrame();
        Shoot = shoot.WasPressedThisFrame();
    }
}