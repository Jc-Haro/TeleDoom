using UnityEngine;
using UnityEngine.AI;

public class NavMesmMovement : MonoBehaviour
{
    [SerializeField] private EnemyMovement EM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private NavMeshAgent NMAgent;
    public void IA()
    {
        EM.EditAnimator(2);
        NMAgent.SetDestination(ES.Target.transform.position);
    }

    // navmesh change enable or disable
    public void NavChange(bool valeu)
    {
        NMAgent.enabled = valeu;
    }
}
