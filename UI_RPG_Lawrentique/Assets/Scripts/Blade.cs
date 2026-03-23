using UnityEngine;

public class Blade : Weapon
{

    public float minDamage, MaxDamage;
    
    public override float GetDamage()
    {
        return Random.Range(minDamage, MaxDamage);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
