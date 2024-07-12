using UnityEngine;

public class bulletStats : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    public float Damage
    {
        get 
        { 
            return damage; 
        }
        set
        {
            damage = value;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public float LifeTime
    { 
        get
        {
            return lifeTime;
        }
    }
}
