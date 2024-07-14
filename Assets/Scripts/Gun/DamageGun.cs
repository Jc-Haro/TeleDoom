using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange; 
    public int maxBullets; // The maximum number of bullets in the magazine
    public int bulletAmount; // How many shots are fired at once
    public bool shotgun;
    [SerializeField] private int bullets; // Current bullets in the magazine
    [SerializeField] public GameObject rocketExplosionPrefab;
    private Transform playerCamera; 
    WeaponSwitcher weaponSwitcher;
    [SerializeField]Transform bulletStartPosition;
    [SerializeField]TrailRenderer bulletTrail;
    [SerializeField]PlaySound sound;

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
            sound.PlaySoundOneShot();
            for (int i = 0; i < bulletAmount; i++) // Loop to shoot multiple bullets
            {
                // We create a little deviation for each bullet with random values on each axis
                Vector3 deviation = playerCamera.forward;
                if (shotgun)
                {
                    deviation.x += Random.Range(-0.1f, 0.1f);
                    deviation.y += Random.Range(-0.1f, 0.1f);
                    deviation.z += Random.Range(-0.1f, 0.1f);
                    deviation.Normalize(); // Normalize the direction vector
                }


                // Create a ray from the camera position in the deviated direction
                Ray gunRay = new Ray(bulletStartPosition.position, deviation);
                // Draw the ray in the scene
                Debug.DrawRay(bulletStartPosition.position, deviation * bulletRange, Color.red, 2.0f);
                //Create trail effect 
                TrailRenderer trail = Instantiate(bulletTrail, bulletStartPosition.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, bulletStartPosition.position + (deviation * bulletRange)));


                // Check if the ray hits something
                if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
                {
                    Debug.Log("La bala golpeó: " + hitInfo.collider.name); 
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
                        Debug.Log("Daño a enemigo, nueva vida:" + enemy.Life);
                    }
                }
                else
                {
                    Debug.Log("No se disparó a nada");
                }
            }
        }
        else //When we run out of bullets
        {
            Debug.Log("se acabaron las balas, nueva arma");
            weaponSwitcher.GetRandomWeapon();
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer _trail, Vector3 _point)
    {
        float time = 0;
        Vector3 startPosition = _trail.transform.position;
        while (time < 1 && _trail != null)
        {
            _trail.transform.position = Vector3.Lerp(startPosition, _point, time);
            time += Time.deltaTime/_trail.time;
            yield return null;
        }
        if(_trail != null)
        {
            Destroy(_trail.gameObject,_trail.time);
        }
    }

    public void GrenadeShoot()
    {
        if (bullets >= 0)
        {
            bullets--;
            sound.PlaySoundOneShot();
        }
        else
        {
            Debug.Log("No more grenades, switching weapons");
            weaponSwitcher.GetRandomWeapon(); 
        }
    }
}
