using UnityEngine;
using UnityEngine.AI;

public class EyeManager : MonoBehaviour
{
    // eye scripts
    [SerializeField] private EyeRandomMovement ERM;
    [SerializeField] private EyeAttack EA;
    [SerializeField] private EyeCheasing EC;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private EyeRaycats ER;

    [SerializeField] Animator anim;
    [SerializeField] private NavMeshAgent NMAgent;

    private void Start()
    {
        NMAgent.enabled = false;
    }
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
                ERM.RandomMoveUpdate();
            }
        }
        else
        {
            ERM.RandomMoveUpdate();
        }
    }

    private void MachineMind()
    {
        if (!ES.IsDead)
        {
            if (ES.ActualDistance < ES.FollowingDistance)
            {
                var lookPose = ES.Target.transform.position - transform.position;
                lookPose.y = 0;
                var rotation = Quaternion.LookRotation(lookPose);
                transform.rotation = rotation;
                ER.RaycastUpdate();
                if (ER.HitPlayer)
                {
                    EA.attack();
                }
                else 
                {
                    ERM.RandomMoveUpdate();
                }
            }
            else
            {
                ERM.RandomMoveUpdate();
            }
        }
        else
        {
            EC.Chasing();
        }

    }

    public void Animation(int valeu)
    {
        anim.SetInteger("Animation", valeu);
    }

    public void NavMesh(bool valeu)
    {
        NMAgent.enabled = valeu;
    }
    public void NavMEshObjective()
    {
        NMAgent.SetDestination(ES.Target.transform.position);
    }
}

