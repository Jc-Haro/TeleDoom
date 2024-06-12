using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private EnemyMovement EM;
    [SerializeField] private EnemyStats ES;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!ES.IsDead)
            {
                Debug.Log("c pego");
                //deal damage
                EM.Attack();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!ES.IsDead)
            {
                Debug.Log("ist attacking");
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!ES.IsDead)
            {
                Debug.Log("corrio");
                // stop atacking
                EM.Attack();
            }
        }
    }
}
