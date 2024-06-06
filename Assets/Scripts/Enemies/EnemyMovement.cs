using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //this program manage the movement and the target for the enemy

    [SerializeField] private EnemyStats ES;
    [SerializeField] private GameObject target;
    [SerializeField] private int followingDistance;
    [SerializeField] private float speed;
    [SerializeField] private bool hasTarget = false;

    private void Start()
    {
        if (ES.Target() != null)
        {
            target = ES.Target();
            hasTarget = true;
        }
        speed = ES.Speed();

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
            Debug.Log("hay target y se esta a distancia de seguimiento");
            Following();
        }
        else
        {
            Debug.Log("hay target pero esta muy lejos");
        }
    }
    private void Following()
    {
        var lookPose = target.transform.position - transform.position;
        lookPose.y = 0;
        var rotation = Quaternion.LookRotation(lookPose);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
