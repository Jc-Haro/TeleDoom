using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDrop : DropObject
{
    [SerializeField] float shieldAmount;
    [SerializeField] PlaySound sound;
    public override void OnCollect()
    {
        PlayerStats.instance.Shield = shieldAmount;
        sound.PlaySoundOneShot();
    }
}
