using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyType : MonoBehaviour
{
    [SerializeField] EnemyType type;

    private void OnDestroy()
    {
        ScoreManager.instance.AddScore(type);
    }
}
