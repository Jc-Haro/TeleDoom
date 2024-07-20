using System.Collections;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    [SerializeField] private EnemyStats ES;
    [SerializeField] private DroneAttack DA;
    [SerializeField] private DroneMovement DM;
    [SerializeField] private Animator Anim;
 
    private void Update()
    {
        if (ES.HasTarget)
        {
            mind();
        }
    }

    private void mind()
    {
        if (!ES.IsDead)
        {
            if (!ES.IsAttacking)
            {
                AnimManager(2);
                DM.NavMeshMovement(true);
                DM.NavmeshDestination(ES.Target);
            }
            else
            {
                DM.NavMeshMovement(false);
            }
        }
        else
        {
            DM.NavMeshMovement(false);
            StartCoroutine(DeathManager());
        }
    }

    public void AnimManager(int valeu)
    {
        Anim.SetInteger("Animation", valeu);
    }
    IEnumerator DeathManager()
    {
        AnimManager(4);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
