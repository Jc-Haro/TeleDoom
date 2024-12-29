using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGranade : MonoBehaviour
{
    [SerializeField] List<int> collitionsLayers;
    [SerializeField] ParticleSystem particles;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (int layer in collitionsLayers)
        {
            if (collision.gameObject.layer == layer)
            {
                TPPlayer();
            }
        }
    }

    private void Update()
    {
        if (InputManager.instance.ShootReactivateTP)
        {
            TPPlayer();
        }
    }

    private void TPPlayer()
    {
        PlayerStats.instance.gameObject.SetActive(false);
        PlayerStats.instance.gameObject.transform.position = this.gameObject.transform.position;
        PlayerStats.instance.gameObject.SetActive(true);
        Instantiate(particles,transform.position,particles.transform.rotation);
        Destroy(gameObject);
    }
}
