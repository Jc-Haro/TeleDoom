using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropObject : MonoBehaviour
{
    public abstract void OnCollect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
