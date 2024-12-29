using System.Collections;
using UnityEngine;

public class ShootingGrenade : MonoBehaviour
{
    float bulletTimerSeconds;
    [SerializeField] public GameObject explosionPrefab;

    void Update()
    {
        bulletTimerSeconds += Time.deltaTime;
        if (bulletTimerSeconds > 2)
        {
            Destroy(gameObject);
            explosionPrefab.transform.position = this.transform.position;
            Instantiate(explosionPrefab);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bulletTimerSeconds = 0;
            explosionPrefab.transform.position = this.transform.position;
            Instantiate(explosionPrefab);
            Destroy(gameObject);
            StartCoroutine(ExplosionTimer());
        }
        else
        {
            return;
        }
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(explosionPrefab);
    }
}
