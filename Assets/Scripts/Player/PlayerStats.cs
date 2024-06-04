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
    float currentShield;
    [SerializeField] float speed;
    float speedBooster;
    [SerializeField] float jumpForce;
    /*
     TODO: current weapon
     */
    private void Start()
    {
        currentHealt = maxHealth;
        currentShield = maxShield;
    }
    #endregion

    #region GetSet
    public float Healt
    {
        get { return currentHealt; }
        set 
        { 
            currentHealt = currentHealt + value < maxHealth ? currentHealt + value : maxHealth;
            if(currentHealt < 0)
            {
                //TODO play death animation
            }
        } 
    }
    public float Shield
    {
        get { return currentShield; }
        set 
        { 
            currentShield = value > 0 ? 
                //If it's a heal
                currentShield + value < maxShield ? currentShield + value : maxShield 
                //If its's damage
                : ShieldDamage(value); }
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
    private float ShieldDamage(float damage)
    {
        if (damage > currentShield)
        {
            currentHealt += damage+currentShield;
            return 0;
        }
        return damage; 
    }
    #endregion
}
