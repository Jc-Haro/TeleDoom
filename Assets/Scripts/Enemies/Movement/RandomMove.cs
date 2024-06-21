using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] private EnemyMovement EM;
    [SerializeField] private EnemyStats ES;

    [SerializeField] private float indexTime;
    [SerializeField] private float mindcooldown;
    private int grade, randomDesicion;
    private Quaternion angle;
    public void RandomMovement()
    {
        if (indexTime >= mindcooldown)
        {
            randomDesicion = Random.Range(0, 2);
            indexTime = 0;
        }
        switch (randomDesicion)
        {

            case 0:
                EM.EditAnimator(0);
                break;
            // in this case the enemy will walk in a random direction
            case 1:
                grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                randomDesicion++;
                break;
            case 2:
                EM.EditAnimator(1);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 2);
                transform.Translate(Vector3.forward * (.5f * ES.Speed) * Time.deltaTime);
                break;
            default:
                break;
        }
        indexTime += Time.deltaTime;
    }
}
