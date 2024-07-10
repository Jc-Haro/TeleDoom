using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchDrop : DropObject
{
    [SerializeField] GameObject weaponHolder;

    public override void OnCollect()
    {
        WeaponSwitcher.instance.GetRandomWeapon();
        Debug.Log("Changed weapon");
    }
}
