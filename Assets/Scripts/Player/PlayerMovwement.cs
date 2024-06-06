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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //The player can move while in the air, but not as fast as when he is in the ground
        airSpeed = speed / 2;
    }

    void Update()
    {
        // Ground movement
        if (controller.isGrounded)
        {
            //We get the input from both axises
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //We create a new vector based on the input of the player and assign it to the direction of the player
            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                //We apply the jump force to the y axis
                moveDirection.y = jumpForce;
            }
        }
        // air movment (basically same shit different speed)
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 airMove = new Vector3(moveHorizontal, 0.0f, moveVertical);
            airMove = transform.TransformDirection(airMove);
            airMove *= airSpeed;

            //We apply the air move to the moveDirection
            moveDirection.x = airMove.x;
            moveDirection.z = airMove.z;

            // We apply gravity, almost the opposite of the jump
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // We use the move method of the controller so it actually does move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
