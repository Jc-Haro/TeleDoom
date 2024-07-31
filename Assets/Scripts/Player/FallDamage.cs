using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float damage;
    float timerSec;
    public float timeAirLimit;
    [SerializeField] CharacterController player;

    // Variables for downwards raycast
    float distance;
    Vector3 direction;


    void FixedUpdate()
    {
        // Declare values for raycast
        distance = 1.5f;
        direction = new Vector3(0,-1,0);

        // Draws raycast
        Debug.DrawRay(transform.position, direction * distance, Color.green);

        // Checks if player is not on ground
        if (Physics.Raycast(transform.position, direction, distance))
        {
            // Checks if the timer took longer than the maximum time allowed
            if (AirTime() > timeAirLimit)
            {
                GetComponent<PlayerStats>().Healt = damage*timerSec;
            }
            timerSec = 0;
        }
        else
        {
            AirTime();
        }
    }

    // Timer used to count how much time the player remained on air
    float AirTime()
    {
        return timerSec++ * Time.deltaTime;
    }
}
