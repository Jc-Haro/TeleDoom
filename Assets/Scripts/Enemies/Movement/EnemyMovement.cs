using UnityEngine;

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
        Debug.Log("dont has target");
        if (ES.HasTarget)
        {
            Debug.Log("has target");
            if (ES.ActualDistance <= ES.FollowingDistance && !ES.IsDead)
            {
                Debug.Log("actual distance < following distance && !isdead");
                if (!ES.IsAttacking)
                {
                    Debug.Log("if not attacking");
                    if (ES.ActualDistance > ES.StopDistance) 
                    {
                        Debug.Log("stop distance");
                        NMM.NavChange(true);
                        NMM.IA();
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

}
