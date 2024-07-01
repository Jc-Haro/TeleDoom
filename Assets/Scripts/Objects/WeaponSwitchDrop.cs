using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchDrop : DropObject
{
    [SerializeField] GameObject weaponHolder;

    public override void OnCollect()
    {
        weaponHolder.GetComponent<WeaponSwitcher>().GetRandomWeapon();
        Debug.Log("Changed weapon");
    }
}
