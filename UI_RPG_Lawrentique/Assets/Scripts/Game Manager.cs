using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Main UI")]
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, enemyHP;
    [SerializeField] private Character[] enemies;
    [SerializeField] private GameObject gameOverScreen;

    [Header("Weapon UI")] 
    [SerializeField] private TMP_Text weaponNameText;
    [SerializeField] private TMP_Text weaponEffectivenessText;

    [Header("Progression UI")]
    [SerializeField] private Slider experienceSlider;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Slider staminaSlider;
    
    [Header("Locations UI")]
    [SerializeField] private TMP_Text locationText;
    [SerializeField] private RawImage[] locationImages;
    [SerializeField] private string[] locationNames;

    [Header("Other progression stuff")] 
    [SerializeField] private int experiencePerEnemy = 50;
    
    private Character currentEnemy;
    private int currentEnemyIndex = 0;
    private int killedEnemies = 0;
    private int currentLocation = 0;
    private int enemyCycle = 0;
    private float[] baseEnemyHealth;

    void Start()
    {
        gameOverScreen.SetActive(false);

        baseEnemyHealth = new float[enemies.Length];
        for (int t = 0; t < enemies.Length; t++)
            baseEnemyHealth[t] = enemies[t].health;
        
        SetLocation(0);
        SetEnemy(0);
        UpdateUI();
    }
    
    void UpdateUI()
    {
        playerName.text = player.CharName;
        playerHP.text = "HP: " + player.health.ToString("F0");
        
        enemyName.text = currentEnemy.CharName;
        enemyHP.text = "HP: " + currentEnemy.health.ToString("F0");
        
        weaponNameText.text = player.activeWeapon.weaponName;
        weaponEffectivenessText.text = player.activeWeapon.effectivenessText;

        levelText.text = "" + player.level;

        experienceSlider.maxValue = player.experienceForNextLevel;
        experienceSlider.value = player.currentExperience;

        staminaSlider.maxValue = player.maxStamina;
        staminaSlider.value = player.currentStamina;
        
        if (locationNames.Length > currentLocation)
            locationText.text = locationNames[currentLocation];
    }

    public void ChangeWeapon()
    {
        player.NextWeapon();
        UpdateUI();
    }

    public void PlayerAttack()
    {
        if (!player.CanAttack()) 
            return;
        
        player.Attack(currentEnemy);

        if (currentEnemy.health <= 0)
        {
            killedEnemies++;
            player.GainExperience(experiencePerEnemy);
            currentEnemyIndex++;

            if (currentEnemyIndex >= enemies.Length)
            {
                currentEnemyIndex = 0;
                enemyCycle++;
            }

            if (killedEnemies % 3 == 0)
            {
                currentLocation++;
                if (currentLocation >= locationImages.Length)
                    currentLocation = 0;
                
                SetLocation(currentLocation);
            }
            
            SetEnemy(currentEnemyIndex);
            UpdateUI();
            return;
        }
        
        currentEnemy.Attack(player);

        if (player.health <= 0)
        {
            ShowGameOverScreen();
            Debug.Log("You died!");
            UpdateUI();
            return;
        }
        UpdateUI();
    }

    public void PlayerBlock()
    {
        if (currentEnemy == null) return;

        player.Shield();
        currentEnemy.Attack(player);
        
        if (player.health <= 0)
        {
            ShowGameOverScreen();
            Debug.Log("You died!");
            return;
        }
        
        UpdateUI();
    }
    void SetEnemy(int x)
    {
        currentEnemy = enemies[x];

        float scale = 1f + enemyCycle * 0.15f;

        currentEnemy.health = baseEnemyHealth[x] * scale;
        currentEnemy.SetDamageMultiplier(scale);

        for (int t = 0; t < enemies.Length; t++)
        {
            if (t == x)
                enemies[t].Show();
            else
                enemies[t].Hide();
        }

        Debug.Log("New enemy: " + currentEnemy.CharName);
    }

    void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetLocation(int x)
    {
        for (int t = 0; t < locationImages.Length; t++)
        {
            locationImages[t].enabled = t == x;
        }
        if (locationNames.Length > x)
            locationText.text = locationNames[x];
    }
}