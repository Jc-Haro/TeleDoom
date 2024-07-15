using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDrop : DropObject
{
    [SerializeField] float boostDuration;
    [SerializeField] float boostMultiplier;

    public override void OnCollect()
    {
        PlayerStats.instance.SpeedBoost(boostMultiplier, boostDuration);
    }
}
