using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCheasing : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    [SerializeField] bool exploteMode = true;
    public void Chasing()
    {
        if (exploteMode)
        {
            exploteMode = false;
            Debug.Log("explote");
            StartCoroutine("Explote");
        }
        chasing();
    }

    IEnumerator Explote()
    {
        EM.Animation(2);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("AutoDestroy");
        yield return null;
    }
    IEnumerator AutoDestroy()
    {
        EM.Animation(4);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        yield return null;
    }
    
    private void  chasing()
    {

    }
}
