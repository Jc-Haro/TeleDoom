using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMAgent;
    [SerializeField] private EnemyStats ES;

    private void Update()
    {
        if(ES.HasTarget)
        {
            NMAgent.enabled = true;
            NMAgent.SetDestination(ES.Target.transform.position);
        }
        else
        {
            NMAgent.enabled=false;
        }
    }
}
