using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange; 
    public int maxBullets; // The maximum number of bullets in the magazine
    public int bulletAmount; // How many shots are fired at once
    [SerializeField] private int bullets; // Current bullets in the magazine
    [SerializeField] public GameObject rocketExplosionPrefab;
    private Transform playerCamera; 
    WeaponSwitcher weaponSwitcher; 

    void Start()
    {
        playerCamera = Camera.main.transform;
        // Get the WeaponSwitcher component
        weaponSwitcher = GetComponentInParent<WeaponSwitcher>();
    }

    private void OnEnable()
    {
        // Refill the bullets when the weapon is enabled
        bullets = maxBullets;
    }

    public void Shoot()
    {
        if (bullets > 0) // Check if there are bullets left
        {
            bullets--;

            for (int i = 0; i < bulletAmount; i++) // Loop to shoot multiple bullets
            {
                // We create a little deviation for each bullet with random values on each axis
                Vector3 deviation = playerCamera.forward;
                deviation.x += Random.Range(-0.1f, 0.1f); 
                deviation.y += Random.Range(-0.1f, 0.1f); 
                deviation.z += Random.Range(-0.1f, 0.1f); 
                deviation.Normalize(); // Normalize the direction vector

                // Create a ray from the camera position in the deviated direction
                Ray gunRay = new Ray(playerCamera.position, deviation);
                // Draw the ray in the scene
                Debug.DrawRay(playerCamera.position, deviation * bulletRange, Color.red, 2.0f);

                // Check if the ray hits something
                if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
                {
                    Debug.Log("La bala golpe�: " + hitInfo.collider.name); 
                    if (GetComponent<Gun>().rocketLauncher)
                    {
                        rocketExplosionPrefab.transform.position = hitInfo.point;
                        Instantiate(rocketExplosionPrefab);
                    }

                    // Check if the hit object has an EnemyStats component
                    if (hitInfo.collider.gameObject.TryGetComponent(out EnemyStats enemy))
                    {
                        // We apply the damage to the enemy
                        enemy.TakeDamage(damage); 
                        Debug.Log("Da�o a enemigo, nueva vida:" + enemy.Life);
                    }
                }
                else
                {
                    Debug.Log("No se dispar� a nada");
                }
            }
        }
        else //When we run out of bullets
        {
            Debug.Log("se acabaron las balas, nueva arma");
            weaponSwitcher.GetRandomWeapon();
        }
    }

    public void GrenadeShoot()
    {
        if (bullets > 0)
        {
            bullets--;
        }
        else
        {
            Debug.Log("No more grenades, switching weapons");
            weaponSwitcher.GetRandomWeapon(); 
        }
    }
}
