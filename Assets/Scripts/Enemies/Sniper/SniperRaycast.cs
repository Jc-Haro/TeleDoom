using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRaycast : MonoBehaviour
{
    [SerializeField] private SniperMachine SM;
    [SerializeField] private EnemyStats ES;

    [SerializeField] private bool hitPlayer;

    public void  SniperRayCastUpdate()
    {
        var lookPose = ES.Target.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(lookPose);
        transform.rotation = rotation;
        if (ES.Target != null)
        {
            if (ES.Target.activeInHierarchy == true)
            {
                Ray();
            }
        }
    }

    private void Ray()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * ES.ActualDistance);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.transform != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                hitPlayer = true;
            }
            else
            {
                hitPlayer = false;
            }
        }
    }

    public bool HitPlayer
    {
        get
        {
            return hitPlayer;
        }
    }

}
