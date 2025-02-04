using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int MaxHP = 10;
    private int CurrentHP;
    public Text HPText;
    public GameObject GameOverUI;

    void Awake()
    {
        Instance = this;
        CurrentHP = MaxHP;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        UpdateUI();

        if (CurrentHP <= 0)
        {
            ShowFailScreen();
        }
    }

    void UpdateUI()
    {
        HPText.text = "HP: " + CurrentHP;
    }

    void ShowFailScreen()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }
}
