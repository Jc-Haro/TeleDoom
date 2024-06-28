using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : DropObject
{
    [SerializeField] float healAmount;
    public override void OnCollect()
    {
        PlayerStats.instance.Healt = healAmount;
    }
}
