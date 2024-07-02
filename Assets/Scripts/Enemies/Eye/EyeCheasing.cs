using System.Collections;
using UnityEngine;

public class EyeCheasing : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] bool exploteMode = true;
    [SerializeField] bool setObjective = true;
    public void Chasing()
    {
        if (exploteMode)
        {
            exploteMode = false;
            StartCoroutine("Explote");
        }
        if(setObjective)
        {
            EM.NavMEshObjective();
        }

    }

    IEnumerator Explote()
    {

        EM.Animation(2);
        ChasingMovement(true);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("AutoDestroy");
        yield return null;
    }
    IEnumerator AutoDestroy()
    {
        EM.Animation(4);
        setObjective = false;
        ChasingMovement(false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        yield return null;
    }
    
    private void  ChasingMovement(bool valeu)
    {
        EM.NavMesh(valeu);
    }
}
