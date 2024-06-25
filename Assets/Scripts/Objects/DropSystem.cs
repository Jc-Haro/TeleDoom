using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    [SerializeField] GameObject[] objectPool;

    private void OnDestroy()
    {
        int randomIndex = Random.Range(0, objectPool.Length);
        Instantiate(objectPool[randomIndex], transform.position,transform.rotation);
    }
}
