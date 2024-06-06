using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //this progam is the behaviour base from the all enemies stats
    [SerializeField] private float life;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float animationDeadTime;
    [SerializeField] private int followingDistance;
    [SerializeField] private GameObject target;

    // get the target
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    //region created for return all base and necessary valeus
    #region ReturnValeus
    // this funcion return the speed
    public float Speed()
    {
        return speed;
    }
    // this funcion return the damage
    public float Damage()
    {
        return damage;
    }
    // this funcion return the life
    public float Life()
    {
        return life;
    }
    // this funcion will return the following ditance
    public int FollowingDistance()
    {
        return followingDistance;
    }
    // this funcion whill return the target
    public GameObject Target()
    {
        return target;
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