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
        Debug.Log("se activo el metodo shoot");
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange)) 
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out EnemyStats enemy))
            {
                Debug.Log("raycast detecto al enemigo");
                enemy.Life -= damage;
                //Debug.Log("vida del enemigo" + enemy.Life);
            }
        
        }
    }
}
