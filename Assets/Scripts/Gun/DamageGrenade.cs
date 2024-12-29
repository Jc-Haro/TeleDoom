using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGrenade : MonoBehaviour
{
    public float damage;
    float explosionTimer;

    void Update()
    {
        explosionTimer += Time.deltaTime;
        if (explosionTimer > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject.TryGetComponent(out EnemyStats enemy))
        {
            Debug.Log("Hit enemy");
            enemy.TakeDamage(damage);
            Debug.Log("Enemy now at: " + other.GetComponent<EnemyStats>().Life);
        }
    }
}
