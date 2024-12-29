using System.Collections;
using UnityEngine;

public class SniperMachine : MonoBehaviour
{
    [SerializeField] private SniperAttack SA;
    [SerializeField] private SniperRaycast SR;
    [SerializeField] private SniperMove SM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private Animator anim;

    private bool canDeath = true;
    private void Update()
    {
        if (ES.Target != null)
        {
            if (ES.Target.activeInHierarchy == true)
            {
                if (!ES.IsDead)
                {
                    Mind();
                }
                else
                {
                    if (canDeath)
                    {
                        StartCoroutine("IsDeath");
                    }
                }
            }
        }
    }

    private void Mind()
    {
        LookRotation();
        SR.SniperRayCastUpdate();
        if (!ES.IsAttacking)
        {
            if(SR.HitPlayer)
            {
                SA.attack();
            }
            else
            {
                SM.Jump();
            }
        }
    }

    private void LookRotation()
    {
        var lookPose = ES.Target.transform.position - transform.position;
        lookPose.y = 0;
        var rotation = Quaternion.LookRotation(lookPose);
        transform.rotation = rotation;
    }
    public void SetAnimation(int valeu)
    {
        anim.SetInteger("Animation", valeu);
    }

    IEnumerator IsDeath()
    {
        canDeath = false;
        SetAnimation(2);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
        yield return null;
    }
}
