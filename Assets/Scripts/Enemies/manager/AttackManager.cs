using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private EnemyMovement EM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private NavMesmMovement NMM;
    [SerializeField] private float indexTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" player enter to the collider");
            if (!ES.IsDead)
            {
                Debug.Log(" attack player");
                ES.IsAttacking = true;
                NMM.NavChange(false);
                EM.EditAnimator(3);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" player exit to the collider");
            if (!ES.IsDead)
            {
                ES.IsAttacking = false;
                EM.EditAnimator(0);
                EM.enabled = true;
            }
        }
    }
}
