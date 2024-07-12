using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunshot;
    public float fireRate;
    public bool automatic;
    public bool grenadeLauncher;
    public bool rocketLauncher;
    public float currentFireRate;

    void Start()
    {
        // We make the current fire rate the weapons fire rate
        currentFireRate = fireRate;
    }

    void Update()
    {

        if (automatic)
        {
            // this instance makes it so that the event will repeat again as long as the button is still pressed
            if (InputManager.instance.Shoot)
            {
                if (currentFireRate <= 0f)
                {
                    // call the gunshot event which will call the function shoot in other script
                    onGunshot?.Invoke();
                    // After firing, the fire rate resets to its max value
                    currentFireRate = fireRate;
                    Debug.Log("se disparo en automatico");
                }
            }
        }
        else if (grenadeLauncher)
        {
            if (InputManager.instance.Shoot)
            {
                if (currentFireRate <= 0f)
                {
                    onGunshot?.Invoke();
                    currentFireRate = fireRate;
                    Debug.Log("Se disparo una granada");
                }
            }
        }
        else if (rocketLauncher)
        {
            if (InputManager.instance.Shoot)
            {
                if (currentFireRate <= 0f)
                {
                    onGunshot?.Invoke();
                    currentFireRate = fireRate;
                    Debug.Log("Se disparo un misil");
                }
            }
        }
        else
        {
            // with GetMouseButtonDown, this will execute only once button press.
            if (InputManager.instance.AutomaticShoot)
            {
                if (currentFireRate <= 0f)
                {
                    onGunshot?.Invoke();
                    currentFireRate = fireRate;
                    Debug.Log("se disparo semiautomatico");
                }
            }
        }

        // The cooldown of the fire rate goes down
        currentFireRate -= Time.deltaTime;
    }
}
