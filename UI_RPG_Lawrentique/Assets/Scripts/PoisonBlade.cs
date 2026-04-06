using UnityEngine;
using UnityEngine.Serialization;

public class PoisonBlade : Blade
{
    [SerializeField] private float poisonDamage;
    [SerializeField] private int poisonCount;
    
    public override float GetDamage()
    {
        float baseDamage = base.GetDamage();
        if (poisonCount > 0)
        {
            poisonCount--;
            return baseDamage + poisonDamage;
        }
        return baseDamage;
    }
}
