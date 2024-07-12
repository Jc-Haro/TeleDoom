using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponSwitcher;

public class RocketLauncherDrop : DropObject
{
    [SerializeField] GameObject weaponHolder;
    private int lastIndex;
    public override void OnCollect()
    {
        weaponHolder.GetComponent<WeaponSwitcher>().hasRocketLauncher = true;

        lastIndex =  weaponHolder.GetComponent<WeaponSwitcher>().lastIndex;

        weaponHolder.GetComponent<WeaponSwitcher>().weapons[lastIndex].weapon.SetActive(false);
        weaponHolder.GetComponent<WeaponSwitcher>().weapons[4].weapon.SetActive(true);
        Debug.Log("Rocket Launcher Obtained");
    }
}
