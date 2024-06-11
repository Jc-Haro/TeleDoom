using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //this program manage the movement and the target for the enemy
    //other scripts
    [SerializeField] private EnemyStats ES;
    [SerializeField] private AttackManager AM;

    // scripts variables
    [SerializeField] private GameObject target;
    [SerializeField] private int followingDistance;
    [SerializeField] private float speed;
    [SerializeField] private bool hasTarget = false, isAttacking = false;
    [SerializeField] private float indexTime;
    [SerializeField] private float mindcooldown;

    // private variables for moving manage
    private int  grade,randomDesicion;
    private Quaternion angle, rotation;
    [SerializeField] private NavMeshAgent NMAgent;

    private void Start()
    {
        if (ES.Target() != null)
        {
            target = ES.Target();
            hasTarget = true;
        }
        speed = ES.Speed;
        followingDistance = ES.FollowingDistance();
        NMAgent.enabled = false;
    }

    private void Update()
    {
        if (hasTarget)
        {
            IA();
        }
        else
        {
            if (ES.Target() != null)
            {
                target = ES.Target();
                hasTarget = true;
            }
        }
    }

    private void IA()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < followingDistance)
        {
            // animator.SetBool("run", false);
            Vector3 lookPose = target.transform.position - transform.position;
            lookPose.y = 0;
            rotation = Quaternion.LookRotation(lookPose);
            NMAgent.enabled = true;
            NMAgent.SetDestination(target.transform.position);

            //if is attacking will dont move
            if (!isAttacking)
            {

                // animator.SetBool("Walk",false);
                // animator.SetBool("run", true);
            }
        }
        else
        {
            Debug.Log("no esta en rango");
            NMAgent.enabled = false;
            RandomMove();
        }
    }
    private void RandomMove()
    {
        Debug.Log("random move");
        if (indexTime >= mindcooldown)
        {
            randomDesicion = Random.Range(0,2);
            indexTime = 0;
        }
        switch (randomDesicion)
        {

            case 0:
                // animator.SetBool("Walk",false);
                // animator.SetBool("run", false);
                break;
            // in this case the enemy will walk in a random direction
            case 1:
                grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                randomDesicion++;
                break;
            case 2:
                // cal animation of walk 
                // animator.SetBool("Walk",true);
                // animator.SetBool("run", false);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 2);
                transform.Translate(Vector3.forward * (.5f *speed) * Time.deltaTime);
                break;
            default:
                break;
        }
        indexTime += Time.deltaTime;
    }

    public void Attack()
    {
        if(isAttacking)
        {
            //animator.SetBool("attack",false);
            isAttacking = false;
        }
        else
        {
            //animator.SetBool("walk",false);
            //animator.SetBool("run",false);
            //animator.SetBool("attack",true);  
            isAttacking = true;
        }
    }
}
