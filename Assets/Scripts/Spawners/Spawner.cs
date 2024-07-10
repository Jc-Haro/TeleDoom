using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float detectionDistance;
    float spawnCounter = 0;
    

    [SerializeField] GameObject[] enemiesPool;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }

    private void Update()
    {
        spawnCounter += TimeIncrement();
        if (spawnCounter > spawnTime)
        {
            int randomIndex = Random.Range(0, enemiesPool.Length);
            Instantiate(enemiesPool[randomIndex], transform.position, enemiesPool[randomIndex].transform.rotation);
            spawnCounter = 0;
        }
    }

    float TimeIncrement()
    {
        float distance = Vector3.Distance(transform.position,PlayerStats.instance.transform.position);
        if (distance < detectionDistance)
        {
            return Time.deltaTime;
        }
        return 0;
    }
}
