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

    public Animator anim;

    public WeaponsSystemUI weaponsSystemUI;

    private void Start()
    {
        currentHealt = maxHealth;
        weaponsSystemUI.MaxLifePlayer(maxHealth);
        currentShield = maxShield;
        weaponsSystemUI.MaxShieldPlayer(maxShield);
    }
    #endregion

    #region GetSet
    public float Healt
    {
        get { return currentHealt; }
        set 
        { 
            currentHealt = currentHealt + value < maxHealth ? currentHealt + value : maxHealth;
            if(currentHealt <= 0)
            {
                Destroy(gameObject);
            }
            weaponsSystemUI.NewLifePlayer(currentHealt);
            weaponsSystemUI.NewShieldPlayer(currentShield);
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
                : ShieldDamage(value);
            weaponsSystemUI.NewLifePlayer(currentHealt);
            weaponsSystemUI.NewShieldPlayer(currentShield);
        }
            
    }
    public void SpeedBoost(float multiplier, float duration)
    {
        speedBooster = multiplier;
        anim.SetFloat("Booster", speedBooster);
        StopCoroutine(StopSpeedBoost(duration));
        StartCoroutine(StopSpeedBoost(duration));

    }
    IEnumerator StopSpeedBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        speedBooster = 0;
        anim.SetFloat("Booster", speedBooster);
    }
    private float ShieldDamage(float damage)
    {
        if (Mathf.Abs(damage) >= currentShield)
        {
            Healt = (damage-currentShield);
            return 0;
        }
        return currentShield + damage; 
    }
    #endregion
}
