using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMAgent;
    [SerializeField] private EnemyStats ES;

    public void NavMeshMovement(bool valeu)
    {
        NMAgent.enabled = valeu;
    }
    public void NavmeshDestination(GameObject objective)
    {
        NMAgent.SetDestination(objective.transform.position);
    }
}
