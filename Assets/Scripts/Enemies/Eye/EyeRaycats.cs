using System.Collections;
using UnityEngine;

public class EyeRaycats : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] GameObject spawn;

    public void RaycastUpdate()
    {
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
        Debug.Log("drawRay");
        Ray ray = new Ray(spawn.transform.position,ES.Target.transform.position);
        Debug.DrawRay(ray.origin, ray.direction * ES.FollowingDistance);
    }
}
