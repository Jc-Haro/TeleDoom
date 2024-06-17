using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float jumpForce = 13f;
    public float gravity = 23f;
    [SerializeField] private float airSpeed;

    //Direction to where the player moves
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // We get the camera's transform component
    private Transform cameraTransform;

    //Coyote time 
    [SerializeField]float coyoteTime;
    float coyoteTimeCounter;

    //Jump buffer
    [SerializeField] float jumpBuffer;
    float jumpBufferCounter;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Find the main camera
        cameraTransform = Camera.main.transform;
        //The player can move while in the air, but not as fast as when he is in the ground
    }

    void Update()
    {
        // Ground movement
        if (controller.isGrounded)
        {
            //We get the input from both axises
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //We create a new vector based on the input of the player
            Vector3 inputDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Calculate the camera relative direction to move:
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            // Keep the forward and right vectors horizontal
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            // Calculate the direction relative to the camera
            moveDirection = forward * inputDirection.z + right * inputDirection.x;
            moveDirection *= speed;

            coyoteTimeCounter = coyoteTime;
        }
        // air movement
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 airMove = forward * inputDirection.z + right * inputDirection.x;
            airMove *= airSpeed;

            //We apply the air move to the moveDirection
            moveDirection.x = airMove.x;
            moveDirection.z = airMove.z;

            // We apply gravity, almost the opposite of the jump
            moveDirection.y -= gravity * Time.deltaTime;

            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButton("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter>0 && coyoteTimeCounter>0.0f)
        {
            //We apply the jump force to the y axis
            moveDirection.y = jumpForce;
            coyoteTimeCounter = 0;
            jumpBufferCounter = 0;
        }


        // We use the move method of the controller so it actually does move
        controller.Move(moveDirection * Time.deltaTime);


    }
}
