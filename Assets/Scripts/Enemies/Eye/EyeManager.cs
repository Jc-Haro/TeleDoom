using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MonoBehaviour
{
    // eye scripts
    [SerializeField] private EyeRandomMovement ERM;
    [SerializeField] private EyeAttack ET;
    [SerializeField] private EyeCheasing EC;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private EyeRaycats ER;

    [SerializeField] Animator anim;

    private void Update()
    {
        if (ES.Target != null)
        {
            if (ES.Target.activeInHierarchy == true)
            {
                MachineMind();
            }
            else
            {
                ERM.RandomMove();
            }
        }
        else
        {
            ERM.RandomMove();
        }
    }

    private void MachineMind()
    {
        if (ES.ActualDistance < ES.FollowingDistance)
        {
            var lookPose = ES.Target.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(lookPose);
            transform.rotation = rotation;
            //ER.RaycastUpdate();
        }
        else
        {
            ERM.RandomMove();
        }
    }

    public void Animation(int valeu)
    {
        anim.SetInteger("animation", valeu);
    }
}

