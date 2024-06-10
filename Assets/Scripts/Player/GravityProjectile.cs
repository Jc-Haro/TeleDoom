using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityProjectile : MonoBehaviour
{
    Camera playerCamera;
    [SerializeField] float granadeSpeed;
    [SerializeField] GameObject granadePefab;
    [SerializeField] GameObject crossHair;
    bool isReady;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject granadeInstance = (GameObject)Instantiate(granadePefab, playerCamera.transform.position, granadePefab.transform.rotation);
        Vector3 rotation = crossHair.transform.position - playerCamera.transform.position;
        granadeInstance.GetComponent<Rigidbody>().AddForce(rotation.normalized * granadeSpeed, ForceMode.Impulse);
    }
}
