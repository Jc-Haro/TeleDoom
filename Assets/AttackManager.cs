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
                //deal damage
                EM.Attack();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!ES.IsDead)
            {
                // stop atacking
                EM.Attack();
            }
        }
    }
}
