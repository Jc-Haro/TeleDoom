using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singletone 
    public static PlayerStats instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    #region Stats
    [SerializeField] float maxHealth;
    float currentHealt;
    [SerializeField] float maxShield;
    float cuerrentShield;
    [SerializeField] float speed;
    float speedBooster;
    [SerializeField] float jumpForce;
    /*
     TODO: current weapon
     */
    private void Start()
    {
        currentHealt = maxHealth;
        cuerrentShield = maxShield;
    }
    #endregion

    #region GetSet
    public float Healt
    {
        get { return currentHealt; }
        set { currentHealt = currentHealt + value > maxHealth ? currentHealt + value : maxHealth; } 
    }
    public float Shield
    {
        get { return cuerrentShield; }
        set { cuerrentShield = cuerrentShield + value > maxShield ? cuerrentShield + value : maxShield; }
    }
    public void SpeedBoost(float multiplier, float duration)
    {
        speedBooster = multiplier;
        StopCoroutine(StopSpeedBoost(duration));
        StartCoroutine(StopSpeedBoost(duration));

    }
    IEnumerator StopSpeedBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        speedBooster = 0;
    }
    #endregion
}
