using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //this progam is the behaviour base from the all enemies stats
    [SerializeField] private float life;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float animationDeadTime;
    [SerializeField] private float followingDistance;
    [SerializeField] private float stopDistance;
    [SerializeField] private float actualDistance;
    [SerializeField] private GameObject target;
    [SerializeField] private bool hasTarget;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isAttacking;

    // get the target
    private void Start()
    {
        IsDead = false;
    }
    private void Update()
    {
        if (target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
        }
        if(target.activeInHierarchy == false)
        {
            HasTarget = false;
        }
        else
        {
            HasTarget = true;
            actualDistance = Vector3.Distance(transform.position, target.transform.position);
        }
    }
    //region created for return all base and necessary valeus
    #region ReturnValeus
    // this funcion return the speed
    public float Speed
    {
        get
        { 
            return speed; 
        }
    }
    // this funcion return the damage
    public float Damage
    {
        get
        {
            return damage;
        }

    }

    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }
    // this funcion return the life
    public float Life
    {
        get 
        { 
            return life; 
        }
        set
        {
            TakeDamage(value);
        }
    }

    public bool IsDead
    {
        get 
        { 
            return isDead; 
        }
        set
        {
            isDead = value;
        }
    }
    public bool HasTarget
    {
        get
        {
            return hasTarget;
        }
        set
        {
            hasTarget = value;
        }
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
        set
        {
            isAttacking = value;
        }
    }
    // this funcion will return the following ditance
    public float FollowingDistance
    {
        get
        {
            return followingDistance;
        }
    }
    public float StopDistance
    {
        get
        {
            return stopDistance;
        }
    }
    public float ActualDistance
    {
        get
        {
            return actualDistance;
        }
    }
    // this funcion whill return the target

    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }
    
    #endregion

    #region DamageAndDead
    // this funcion recive the damaga an manage the dead animation 
    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            life = 0;
            StartCoroutine("Dead");
        }

    }

    // this funcion is for the enemy dead
    private IEnumerator Dead()
    {
        // here start the dead animation
        yield return new WaitForSeconds(animationDeadTime);
        Destroy(gameObject);
    }

    #endregion
}
