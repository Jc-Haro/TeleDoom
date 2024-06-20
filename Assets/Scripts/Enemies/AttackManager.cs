using Unity.VisualScripting;
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
                ES.IsAttacking = true;
                EM.animator.SetInteger("Animation", 3);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(!ES.IsDead && !ES.IsAttacking)
        {
            ES.IsAttacking = true;
            EM.animator.SetInteger("Animation", 3);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!ES.IsDead)
        {
                ES.IsAttacking = false;
                EM.animator.SetInteger("Animation", 0);

        }
    }

}
