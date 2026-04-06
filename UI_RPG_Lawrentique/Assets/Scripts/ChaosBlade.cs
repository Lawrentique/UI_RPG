using UnityEngine;

public class ChaosBlade : Blade
{
    public override float GetDamage()
    {
        float baseDamage = base.GetDamage();
        float random = Random.value;

        if (random < 0.15f)
        {
            Debug.Log("Weak hit...");
            return baseDamage * 0.75f;
        }
        else if (random < 0.6f)
        {
            return baseDamage;
        }
        else
        {
            Debug.Log("Critical damage!");
            return baseDamage * 2.5f;
        }
    }
}
