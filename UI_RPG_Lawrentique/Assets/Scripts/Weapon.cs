using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    [SerializeField] private CharacterType effectiveAgainst;
    [SerializeField] private float effectivenessMultiplier;
    public string effectivenessText;
    [SerializeField] private RawImage weaponIcon;
    
    public abstract float GetDamage();

    public float GetFinalDamage(Character target)
    {
        float baseDamage = GetDamage();

        if (target != null && target.CharacterType == effectiveAgainst)
        {
            return baseDamage * effectivenessMultiplier;
        }
        return baseDamage;
    }
    
    public void Show()
    {
        if (weaponIcon != null)
            weaponIcon.enabled = true;
    }

    public void Hide()
    {
        if (weaponIcon != null)
            weaponIcon.enabled = false;
    }
}
