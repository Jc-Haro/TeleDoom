using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    public int maxBullets;
    [SerializeField]private int bullets;
    private Transform playerCamera;
    WeaponSwitcher weaponSwitcher;

    void Start()
    {
        playerCamera = Camera.main.transform;
        weaponSwitcher = GetComponentInParent<WeaponSwitcher>();
        
    }

    private void OnEnable()
    {
        bullets = maxBullets;        
    }

    public void Shoot()
    {
        if (bullets > 0)
        {
            Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
            Debug.DrawRay(playerCamera.position, playerCamera.forward * bulletRange, Color.red, 2.0f);
            bullets--;
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
        else
        {
            Debug.Log("se acabaron las balas, nueva arma");
            weaponSwitcher.GetRandomWeapon();
            
        }
    }
}