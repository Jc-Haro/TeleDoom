using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform playerCamera;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        Debug.DrawRay(playerCamera.position, playerCamera.forward * bulletRange, Color.red, 2.0f);

        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            Debug.Log("Raycast hit: " + hitInfo.collider.name);

            if (hitInfo.collider.gameObject.TryGetComponent(out EnemyStats enemy))
            {
                enemy.TakeDamage(damage);
                Debug.Log("Enemy hit! Current enemy life: " + enemy.Life);
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }
}



//Versio original

/*
 
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform playerCamera;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    public void shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange)) 
        { 
            if (hitInfo.collider.gameObject.TryGetComponent(out EnemyStats enemy))
            {
                enemy.Life -= damage;
                Debug.Log("vida del enemigo: " + enemy.Life);
            }
        }
    }
}

 */