using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : DropObject
{
    [SerializeField] float healAmount;
    [SerializeField] PlaySound sound;
    public override void OnCollect()
    {
        PlayerStats.instance.Healt = healAmount;
        sound.PlaySoundOneShot();   
    }
}
