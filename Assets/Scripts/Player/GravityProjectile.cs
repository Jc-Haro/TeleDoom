using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GravityProjectile : MonoBehaviour
{
    Camera playerCamera;
    [SerializeField] float granadeSpeed;
    [SerializeField] GameObject grenadeDamagePrefab;
    [SerializeField] GameObject granadePefab;
    [SerializeField] GameObject crossHair;
    bool isReady;
    float cooldownTimerSeconds;
    [SerializeField] float granadeCooldownSeconds;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        isReady = true;
    }

    void Update()
    {
        if (IsGrandeReady())
        {
            isReady = false;
            cooldownTimerSeconds = 0;
            Shoot();
        }
        if (!isReady)
        {
            cooldownTimerSeconds += Time.deltaTime;
            if (cooldownTimerSeconds > granadeCooldownSeconds)
            {
                isReady = true;
            }
        }
    }

    private bool IsGrandeReady()
    {
        return InputManager.instance.ShootReactivateTP && isReady && GameObject.FindGameObjectsWithTag("Tp").Length == 0;
    }

    private void Shoot()
    {
        if(GetComponentInChildren<Gun>().grenadeLauncher)
        {
            GameObject granadeInstance = (GameObject)Instantiate(grenadeDamagePrefab, playerCamera.transform.position, grenadeDamagePrefab.transform.rotation);
            Vector3 rotation = crossHair.transform.position - playerCamera.transform.position;
            granadeInstance.GetComponent<Rigidbody>().AddForce(rotation.normalized * granadeSpeed * 5, ForceMode.Impulse);
        }
        else
        {
            GameObject granadeInstance = (GameObject)Instantiate(granadePefab, playerCamera.transform.position, granadePefab.transform.rotation);
            Vector3 rotation = crossHair.transform.position - playerCamera.transform.position;
            granadeInstance.GetComponent<Rigidbody>().AddForce(rotation.normalized * granadeSpeed, ForceMode.Impulse);
        }
    }
}
