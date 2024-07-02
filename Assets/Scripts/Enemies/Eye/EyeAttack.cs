using UnityEngine;

public class EyeAttack : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] GameObject spawnAttack;
    [SerializeField] GameObject bullet;
    public void attack()
    {
        EM.Animation(3);
    }
    public void SpawnAttack()
    {
        GameObject balaTemp = Instantiate(bullet, spawnAttack.transform.position,spawnAttack.transform.rotation) as GameObject;
        balaTemp.GetComponent<bulletStats>().Damage = ES.Damage;
        Rigidbody rb = balaTemp.GetComponent<Rigidbody>();
        rb.AddForce((ES.Target.transform.position - spawnAttack.transform.position) * bullet.GetComponent<bulletStats>().Speed);
        Destroy(balaTemp, bullet.GetComponent<bulletStats>().LifeTime);
    }
}
