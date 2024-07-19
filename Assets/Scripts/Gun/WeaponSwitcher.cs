using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public static WeaponSwitcher instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [Serializable]
    public struct Weapon
    {
        public GameObject weapon;
        public Transform bulletStart;
    }
    public List<Weapon> weapons;
    public int lastIndex;
    public bool hasRocketLauncher = false;

    void Start()
    {
        // First deactivates all weapons, just in case
        foreach (var weapon in weapons)
        {
            weapon.weapon.SetActive(false);
        }

        // Activates a random weapon
        lastIndex = UnityEngine.Random.Range(0, weapons.Count);
        if (weapons[lastIndex].weapon == weapons[4].weapon && !hasRocketLauncher)
            GetRandomWeapon();
        else
        {
            weapons[lastIndex].weapon.SetActive(true);
            weapons[lastIndex].weapon.GetComponent<WeaponOnAble>().WeaponAble();
        }
    }

    // Function to get a new random weapon, without repeating the last one
    public void GetRandomWeapon()
    {
        weapons[4].weapon.SetActive(false);
        hasRocketLauncher = false;

        // Current weapon gets deactivated
        weapons[lastIndex].weapon.SetActive(false);

        int newIndex;

        // Creates a new index for the new weapon, if its the same as the current weapon it will create a new one until its different
        do
        {
            newIndex = UnityEngine.Random.Range(0, weapons.Count);
        } while (newIndex == lastIndex);

        // The weapon index copies the new index and activates that weapon
        lastIndex = newIndex;
        weapons[lastIndex].weapon.SetActive(true);
        weapons[lastIndex].weapon.GetComponent<WeaponOnAble>().WeaponAble();
        Debug.Log("new weapon: " + lastIndex);

        if(weapons[4].weapon.activeSelf && !hasRocketLauncher)
        {
            GetRandomWeapon();
        }
    }
}
