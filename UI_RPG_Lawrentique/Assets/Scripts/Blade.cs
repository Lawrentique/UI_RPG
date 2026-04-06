using UnityEngine;

public class Blade : Weapon
{

    [SerializeField] private float minDamage, MaxDamage;
    
    public override float GetDamage()
    {
        return Random.Range(minDamage, MaxDamage);
    }
}
