using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float health;
    [SerializeField] private string charName;
    
    public string CharName
    {
        get { return charName; }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(CharName + " took " + damage + " damage! Health: " + health);
    }

    public void TakeDamage(Weapon thrownWeapon)
    {
        float damage = thrownWeapon.GetDamage();
        TakeDamage(damage);
        
    }

    public abstract void Attack(Character toHit);
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
