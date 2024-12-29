using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAttack : MonoBehaviour
{
    [SerializeField] private SniperMachine SM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] GameObject spawnAttack;
    [SerializeField] GameObject bullet;

    public void attack()
    {
        SM.SetAnimation(1);
    }
    public void SpawnAttack()
    {
        GameObject balaTemp = Instantiate(bullet, spawnAttack.transform.position, spawnAttack.transform.rotation) as GameObject;
        balaTemp.GetComponent<bulletStats>().Damage = ES.Damage;
        Rigidbody rb = balaTemp.GetComponent<Rigidbody>();
        rb.AddForce((ES.Target.transform.position - spawnAttack.transform.position) * bullet.GetComponent<bulletStats>().Speed);
        Destroy(balaTemp, bullet.GetComponent<bulletStats>().LifeTime);
    }

}
