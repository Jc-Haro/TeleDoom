using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats ES;
    [SerializeField] private DroneMovement DM;
    [SerializeField] private DroneManager DManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("toca al jugador");
            ES.IsAttacking = true;
            DManager.AnimManager(3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("no toca al jugador");
            ES.IsAttacking = false;
            DManager.AnimManager(0);
        }
    }
}
