using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> weapons; // Lista de GameObjects de las armas
    private int lastIndex; // Índice del último objeto seleccionado, privado para no ser modificado externamente

    void Start()
    {
        // Desactiva todas las armas al inicio
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Activa una arma aleatoria al inicio
        lastIndex = Random.Range(0, weapons.Count);
        weapons[lastIndex].SetActive(true);
    }

    // Función para elegir un objeto aleatoriamente sin repetir el último
    public void GetRandomWeapon()
    {
        // Desactiva el arma actual
        weapons[lastIndex].SetActive(false);

        int newIndex;

        // Encuentra un nuevo índice aleatorio diferente del último
        do
        {
            newIndex = Random.Range(0, weapons.Count);
        } while (newIndex == lastIndex);

        // Actualiza el índice y activa la nueva arma
        lastIndex = newIndex;
        weapons[lastIndex].SetActive(true);
    }
}
