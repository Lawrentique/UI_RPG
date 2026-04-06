using UnityEngine;

public class EnemyWarrior : Character
{
    [SerializeField] private float minDamage, maxDamage;

    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage) * damageMultiplier;
        toHit.TakeDamage(damage);

        Debug.Log(CharName + " hits the player for " + damage + " damage!");
        
        PlaySound(hitSound);
    }
}
