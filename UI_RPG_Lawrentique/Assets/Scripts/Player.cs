using UnityEngine;

public class Player : Character
{
    public Weapon activeWeapon;
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private int currentWeapon = 0;

    [Header("Shield")] 
    private bool useShield = false;
    [SerializeField] private float blockedDamagePercent = 0.1f;
    [SerializeField] private float blockChance = 0.8f;
    [SerializeField] private AudioClip hitShieldSound;
    [SerializeField] private AudioClip breakShieldSound;

    [Header("Leveling")] 
    public int level = 1;
    public int currentExperience = 0;
    public int experienceForNextLevel = 100;
    public float maxHealth = 100f;
    [SerializeField] private float healthBoostForNextLevel = 12f;
    [SerializeField] private float damageBoostForNextLevel = 0.1f;

    [Header("Stamina")] 
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    [SerializeField] private float staminaPerAttack = 25f;

    void Start()
    {
        maxHealth = health;
        currentStamina = maxStamina;
        SetWeapon(0);
    }

    public bool CanAttack()
    {
        return currentStamina >= staminaPerAttack;
    }

    void SetWeapon(int x)
    {
        currentWeapon = x;
        activeWeapon = weapons[x];

        for (int t = 0; t < weapons.Length; t++)
        {
            if (t == x)
                weapons[t].Show();
            else
                weapons[t].Hide();
        }
    }

    public void NextWeapon()
    {
        currentWeapon++;

        if (currentWeapon >= weapons.Length)
        {
            currentWeapon = 0;
        }
        SetWeapon(currentWeapon);
    } 
    
    public override void Attack(Character enemyToHit)
    {
        if(!CanAttack())
            return;

        currentStamina -= staminaPerAttack;
        
        float damage = activeWeapon.GetFinalDamage(enemyToHit);
        enemyToHit.TakeDamage(damage);
        
        PlaySound(hitSound);
    }

    public void Shield()
    { 
        useShield = true;
        currentStamina = maxStamina;
    }

    public override void TakeDamage(float damage)
    {
        if (useShield)
        {
            useShield = false;

            if (Random.value <= blockChance)
            {
                damage *= blockedDamagePercent;
                Debug.Log("Blocked! Damage: " + damage);
                PlaySound(hitShieldSound);
            }
            else
            {
                Debug.Log("Block failed!");
                PlaySound(breakShieldSound);
            }
        }

        base.TakeDamage(damage);
    }

    public void GainExperience(int experience)
    {
        currentExperience += experience;

        while (currentExperience >= experienceForNextLevel)
        {
            currentExperience -= experienceForNextLevel;
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        experienceForNextLevel += 25;
        maxHealth += healthBoostForNextLevel;
        damageMultiplier += damageBoostForNextLevel;
        float healAmount = maxHealth * 0.6f;
        health += healAmount;
        
        if (health > maxHealth)
            health = maxHealth;
    }
}
