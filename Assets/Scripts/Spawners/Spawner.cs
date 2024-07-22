using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float detectionDistance;
    public Vector3 vTransform;
    float spawnCounter = 0;
    

    [SerializeField] GameObject[] enemiesPool;
    [SerializeField] private GameObject player;
    private void Start()
    {
        player = PlayerStats.instance.gameObject;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }

    private void Update()
    {
        vTransform = transform.position;
        spawnCounter += TimeIncrement();
        if (spawnCounter > spawnTime)
        {
            if (transform.position.y < 39)
            {
                int randomIndex = Random.Range(0, 2);
                Instantiate(enemiesPool[randomIndex], transform.position, enemiesPool[randomIndex].transform.rotation);
                spawnCounter = 0;
            }
            else
            {
                int randomIndex = Random.Range(2, 4);
                Instantiate(enemiesPool[randomIndex], transform.position, enemiesPool[randomIndex].transform.rotation);
                spawnCounter = 0;
            }
        }
    }

    float TimeIncrement()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < detectionDistance)
            {
                return Time.deltaTime;
            }
        }
        return 0;
    }
}
