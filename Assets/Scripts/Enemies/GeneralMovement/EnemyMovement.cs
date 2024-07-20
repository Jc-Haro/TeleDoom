using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //this program manage the movement and the target for the enemy

    //other scripts
    [SerializeField] private EnemyStats ES;
    [SerializeField] private AttackManager AM;
    [SerializeField] private RandomMove RM;
    [SerializeField] private NavMesmMovement NMM;


    // private variables for moving manage
    public Animator animator;
    [SerializeField] private GameObject heat;
    [SerializeField] private bool canEntry = true;

    private void Update()
    {
        if(!ES.IsDead)
        {
            if (ES.HasTarget)
            {
                mind();
            }
            else
            {
                NMM.NavChange(false);
                RM.RandomMovement();
            }
        }
        else
        {
            NMM.NavChange(false);
            if (canEntry)
            {
                canEntry = false;
                StartCoroutine("Dead");
            }
        }
    }
    private void mind()
    {
        if (ES.ActualDistance <= ES.FollowingDistance)
        {
            var lookPose = ES.Target.transform.position - transform.position;
            lookPose.y = 0;
            var rotation = Quaternion.LookRotation(lookPose);
            transform.rotation = rotation;
            if (!ES.IsAttacking)
            {
                if (ES.ActualDistance > ES.StopDistance)
                {
                    NMM.NavChange(true);
                    NMM.IA();
                }
                else
                {
                    NMM.NavChange(false);
                }
            }
            else
            {
                NMM.NavChange(false);
            }
        }
        else
        {
            NMM.NavChange(false);
            RM.RandomMovement();
        }
    }
    IEnumerator Dead()
    {
        EditAnimator(4);
        yield return new WaitForSeconds(2F);
        if (ES.IsTank)
        {
            Instantiate(heat);
        }
        Destroy(gameObject);
        yield return null;
    }
    public void Attack()
    {
        Debug.Log("enemyAttack");
        PlayerStats.instance.Shield = ES.Damage;
    }

    public void EditAnimator(int value)
    {
        animator.SetInteger("Animation", value);
    }
}
