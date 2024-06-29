using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyType : MonoBehaviour
{
    [SerializeField] EnemyType type;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }


    private void OnDestroy()
    {
        if (!isQuitting)
        {
            ScoreManager.instance.AddScore(type);
        }
    }
}
