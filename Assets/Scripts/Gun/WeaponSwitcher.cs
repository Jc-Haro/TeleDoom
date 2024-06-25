using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> weapons;
    private int lastIndex;

    void Start()
    {
        // First deactivates all weapons, just in case
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Activates a random weapon
        lastIndex = Random.Range(0, weapons.Count);
        weapons[lastIndex].SetActive(true);
    }

    // Function to get a new random weapon, without repeating the last one
    public void GetRandomWeapon()
    {
        // Current weapon gets deactivated
        weapons[lastIndex].SetActive(false);

        int newIndex;

        // Creates a new index for the new weapon, if its the same as the current weapon it will create a new one until its different
        do
        {
            newIndex = Random.Range(0, weapons.Count);
        } while (newIndex == lastIndex);

        // The weapon index copies the new index and activates that weapon
        lastIndex = newIndex;
        weapons[lastIndex].SetActive(true);
    }
}
