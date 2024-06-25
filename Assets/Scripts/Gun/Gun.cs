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
    public float currentFireRate;

    void Start()
    {
        currentFireRate = fireRate;
        
    }

    void Update()
    {

        if (automatic)
        {
            if (InputManager.instance.Shoot)
            {
                if (currentFireRate <= 0f)
                {
                    onGunshot?.Invoke();
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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0f)
                {
                    onGunshot?.Invoke();
                    currentFireRate = fireRate;
                    Debug.Log("se disparo semiautomatico");
                }
            }
        }
        currentFireRate -= Time.deltaTime;
    }
}
