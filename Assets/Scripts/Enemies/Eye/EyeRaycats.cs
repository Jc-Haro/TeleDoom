using System.Collections;
using UnityEngine;
using UnityEngine.iOS;

public class EyeRaycats : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] private bool hitPlayer;
    [SerializeField] GameObject rayObject;

    public void RaycastUpdate()
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
        Ray ray = new Ray(transform.position,transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * ES.FollowingDistance);
        RaycastHit hit;
        Physics.Raycast(ray,out hit);
        if(hit.transform != null)
        {
            if (hit.transform.CompareTag("Player"))
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
