using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, enemyHP;
    
    void Start()
    {
        UpdateUI();
    }
    
    void UpdateUI()
    {
        playerName.text = player.CharName;
        playerHP.text = "HP: " + player.health.ToString("F1");
        
        enemyName.text = enemy.CharName;
        enemyHP.text = "HP: " + enemy.health.ToString("F1");
    }

    public void PlayerAttack()
    {
        player.Attack(enemy);
        enemy.Attack(player);
        UpdateUI();
    }
}
