using UnityEngine;

public class PoisonBlade : Blade
{

    [SerializeField] float poisonDamage;
    [SerializeField] int poisonCount;
    
    public override float GetDamage()
    {
        float baseDamage = base.GetDamage();
        if (poisonCount > 0)
        {
            poisonCount--;
            return baseDamage * poisonDamage;
        }
        return baseDamage;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
