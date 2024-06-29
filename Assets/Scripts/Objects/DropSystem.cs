using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    [SerializeField] GameObject[] objectPool;
    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            int randomIndex = Random.Range(0, objectPool.Length);
            Instantiate(objectPool[randomIndex], transform.position,transform.rotation);
        }
    }
}
