using UnityEngine;

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
    private int randomDesicion, grade;
    private Quaternion angle, rotation;

    private void Start()
    {
        if (ES.Target() != null)
        {
            target = ES.Target();
            hasTarget = true;
        }
        speed = ES.Speed;
        followingDistance = ES.FollowingDistance();

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
            // cansel animation of run
            // animator.SetBool("run", false);
            Vector3 lookPose = target.transform.position - transform.position;
            lookPose.y = 0;
            rotation = Quaternion.LookRotation(lookPose);
            //if is attacking will dont move
            if (!isAttacking)
            {
                Following();
            }

        }
        else
        {
            RandomMove();
        }
    }
    private void Following()
    {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
        // animator.SetBool("Walk",false);
        // animator.SetBool("run", true);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void RandomMove()
    {
        if(indexTime >= mindcooldown)
        {
            randomDesicion = Random.Range(0,2);
            indexTime = 0;
        }
        switch (randomDesicion)
        {
            //In this case the enemy whill stay quiet
            case 0:
                // call animator for stop walk and call idle
                // animator.SetBool("Walk",false);
                break;
            // in this case the enemy will walk in a random direction
            case 1:
                grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                randomDesicion++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 2);
                transform.Translate(Vector3.forward * (.5f *speed) * Time.deltaTime);
                // cal animation of walk 
                // animator.SetBool("Walk",true);
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
