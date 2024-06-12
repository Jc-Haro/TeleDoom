using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunshot;
    public float fireRate;
    public bool automatic;
    public float currentFireRate;
    void Start()
    {
        currentFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic) 
        { 
            if(Input.GetMouseButton(0)) 
            {
                if(fireRate <= 0f)
                {
                    onGunshot.Invoke();
                    currentFireRate = fireRate;
                }
        }
        else
        {
            }if(Input.GetMouseButtonDown(0)) 
            {
                if(fireRate <= 0f)
                {
                    onGunshot.Invoke();
                    currentFireRate = fireRate;
                }
            }
        }
        currentFireRate -= Time.deltaTime;
    }
}
