using UnityEngine;

public class Enemy : Character
{
    
    [SerializeField] private float minDamage, MaxDamage;
    
    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, MaxDamage);
        toHit.TakeDamage(damage);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
