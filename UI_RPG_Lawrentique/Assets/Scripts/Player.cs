using UnityEngine;

public class Player : Character
{

    [SerializeField] private Weapon activeWeapon;
    
    public override void Attack(Character enemyToHit)
    {
        float damage = activeWeapon.GetDamage();
        enemyToHit.TakeDamage(damage);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
