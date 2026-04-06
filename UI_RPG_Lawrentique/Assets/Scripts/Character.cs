using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public float health;
    [SerializeField] private string charName;
    [SerializeField] private RawImage characterImage;
    [SerializeField] private CharacterType characterType;
    
    [Header("Sound parameters")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSound;

    [Header("Visual damage parameters")] 
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private float damageTextTime = 0.7f;

    protected float damageMultiplier = 1f;

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }
    
    public string CharName
    {
        get { return charName; }
    }

    public CharacterType CharacterType
    {
        get { return characterType; }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(CharName + " took " + damage + " damage! Health: " + health);
        
        ShowDamageText(damage);
    }
    public void Show()
    {
        gameObject.SetActive(true);

        if (characterImage != null)
            characterImage.enabled = true;

        if (damageText != null)
            damageText.text = "";
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        if (characterImage != null)
            characterImage.enabled = false;
    }

    protected void PlaySound(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(clip);
    }

    void ShowDamageText(float damage)
    {
        if (damageText == null) return;

        StopAllCoroutines();
        damageText.text = "-" + damage.ToString("F0");
        StartCoroutine(ClearDamageText());
    }

    IEnumerator ClearDamageText()
    {
        yield return new WaitForSeconds(damageTextTime);

        if (damageText != null)
            damageText.text = "";
    }

    public abstract void Attack(Character toHit);
}
