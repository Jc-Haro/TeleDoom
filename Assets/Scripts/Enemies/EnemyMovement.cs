using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //this program manage the movement and the target for the enemy

    [SerializeField] private EnemyStats ES;
    [SerializeField] private GameObject target;
    [SerializeField] private int followingDistance;
    [SerializeField] private float speed;
    [SerializeField] private bool hasTarget = false;
    [SerializeField] private float indexTime;
    [SerializeField] private float mindcooldown;
    public int randomDesicion, grade;
    public Quaternion angle;
    private void Start()
    {
        if (ES.Target() != null)
        {
            target = ES.Target();
            hasTarget = true;
        }
        speed = ES.Speed();
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
            Debug.Log("no hay target");
            if (ES.Target() != null)
            {
                target = ES.Target();
            }
        }
    }

    private void IA()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < followingDistance)
        {
            Following();
        }
        else
        {
            RandomMove();
        }
    }
    private void Following()
    {
        Vector3 lookPose = target.transform.position - transform.position;
        lookPose.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPose);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
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

                break;
            // in this case the enemy will walk in a random direction
            case 1:
                Debug.Log("case1");
                grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                randomDesicion++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 2);
                transform.Translate(Vector3.forward * (.5f *speed) * Time.deltaTime);
                break;
            default:
                break;
        }
        indexTime += Time.deltaTime;
    }
}
