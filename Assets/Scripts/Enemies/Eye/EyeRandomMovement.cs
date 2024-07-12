using UnityEngine;

public class EyeRandomMovement : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] private float indextime;
    [SerializeField] private float coldown;
    [SerializeField] private int selection;
    [SerializeField] private Quaternion angle;
    public void RandomMoveUpdate()
    {
        if (coldown < indextime)
        {
            indextime = 0;
            EM.Animation(0);
            selection = Random.Range(0, 2);
        }
        indextime += Time.deltaTime;

        RandomMove();
    }

    private void RandomMove()
    {
        switch (selection)
        {
            case 0:
                EM.Animation(0);
            break;
            case 1:
                var grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                selection++;
            break;
            case 2:
                EM.Animation(1);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 2);
                transform.Translate(Vector3.forward * (.5f * ES.Speed) * Time.deltaTime);
            break;
        }
    }
}
