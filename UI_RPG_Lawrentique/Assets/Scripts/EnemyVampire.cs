using UnityEngine;

public class EnemyVampire : Character
{
    
    [SerializeField] private float minDamage, maxDamage;
    [SerializeField] private float healPercent = 0.5f;
    
    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage) * damageMultiplier;
        toHit.TakeDamage(damage);
        
        float healAmount = damage * healPercent;
        health += healAmount;
        
        Debug.Log(CharName + " drains life for " + damage + " damage and heals " + healAmount + "health points!");

        PlaySound(hitSound);
    }
}
