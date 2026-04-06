using UnityEngine;

public class EnemyMage : Character
{

    private int turnCount = 0;
    
    public override void Attack(Character toHit)
    {
        turnCount++;

        if (turnCount < 3)
        {
            Debug.Log(CharName + " is charging a spell (" + turnCount + "/2)");
            return;
        }

        float damage = toHit.health * 0.6f;
        toHit.TakeDamage(damage);
        
        Debug.Log(CharName + " casts a powerful spell and deals " + damage + " damage!");
        
        turnCount = 0;
        
        PlaySound(hitSound);
    }
}
