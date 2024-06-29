using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRandomMovement : MonoBehaviour
{
    [SerializeField] EnemyStats ES;
    [SerializeField] EyeManager EM;
    public void RandomMove()
    {
        EM.Animation(0);
    }
}
