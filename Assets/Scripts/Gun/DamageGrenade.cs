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
        Debug.Log("Hit enemy");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage);
            Debug.Log("Enemy now at: " + other.GetComponent<EnemyStats>().Life);
        }
    }
}
