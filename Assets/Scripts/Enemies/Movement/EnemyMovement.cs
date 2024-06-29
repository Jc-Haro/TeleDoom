using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    //this program manage the movement and the target for the enemy

    //other scripts
    [SerializeField] private EnemyStats ES;
    [SerializeField] private AttackManager AM;
    [SerializeField] private RandomMove RM;
    [SerializeField] private NavMesmMovement NMM;

    // scripts variables
    RigidbodyConstraints originalConstrain;
    

    // private variables for moving manage
    public Animator animator;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalConstrain = rb.constraints;
    }

    private void Update()
    {
        if (ES.HasTarget)
        {
            if (ES.ActualDistance <= ES.FollowingDistance && !ES.IsDead)
            {
                if (!ES.IsAttacking)
                {
                    var lookPose = ES.Target.transform.position - transform.position;
                    lookPose.y = 0;
                     var rotation = Quaternion.LookRotation(lookPose);
                    transform.rotation = rotation;
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
        else
        {
            NMM.NavChange(false);
            RM.RandomMovement();
        }
    }


    public void Attack()
    {
        PlayerStats.instance.Shield = ES.Damage;
    }

    public void EditAnimator(int value)
    {
        animator.SetInteger("Animation", value);
    }
}
