using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropObject : MonoBehaviour
{
    [SerializeField] GameObject collectParticle;
    public abstract void OnCollect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 spawnOffset = new Vector3(0,1,0);
            OnCollect();
            Instantiate(collectParticle, transform.position + spawnOffset, collectParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
}
