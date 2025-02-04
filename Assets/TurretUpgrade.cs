using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrade : MonoBehaviour
{

    public static TurretUpgrade Instance;
    public int Gold = 100;  // Starting gold
    public Text GoldText;

    public int FireRateLevel = 1;
    public int RangeLevel = 1;
    public int BulletDistanceLevel = 1;

    public int FireRateCost = 50;
    public int RangeCost = 75;
    public int BulletDistanceCost = 100;

    public Turret turret;  // Reference to the turret

    public List<Turret> Turrets = new List<Turret>();

    void Awake()
    {
        Instance = this;
        UpdateGoldUI();
    }

    void Start()
    {
        UpdateGoldUI();
    }


    void UpdateGoldUI()
    {
        GoldText.text = "Gold: " + Gold;
    }

    public void UpgradeFireRate()
    {
        if (Gold >= FireRateCost)
        {
            Gold -= FireRateCost;
            FireRateLevel++;
            turret.FireRate *= 1.2f;  // Increase fire rate
            FireRateCost += 25; // Increase cost

            foreach (Turret turret in Turrets)
            {
                turret.FireRate *= 1.2f;
            }

            UpdateGoldUI();

            Debug.Log("Fire Rate Upgraded!"); //  Debug message
        }
    }

    public void UpgradeRange()
    {
        if (Gold >= RangeCost)
        {
            Gold -= RangeCost;
            RangeLevel++;
            turret.Range += 1.5f;  // Increase attack range
            RangeCost += 30;

            foreach (Turret turret in Turrets)
            {
                turret.Range *= 1.5f;
            }

            UpdateGoldUI();

            Debug.Log("Fire Range Upgraded!"); //  Debug message
        }
    }

    public void UpgradeBulletKillDistance()
    {
        if (Gold >= BulletDistanceCost)
        {
            Gold -= BulletDistanceCost;
            BulletDistanceLevel++;
            turret.BulletDistance += 2.0f;  // Increase bullet kill distance
            BulletDistanceCost += 40;

            foreach (Turret turret in Turrets)
            {
                turret.BulletDistance *= 2.0f;
            }

            UpdateGoldUI();

            Debug.Log("BD Upgraded!"); //  Debug message
        }
    }

    public void EarnGold(int amount)
    {
        Gold += amount;
        UpdateGoldUI();
    }

    public void RegisterTurret(Turret turret)
    {
        if (!Turrets.Contains(turret) && Turrets.Count < 6)
        {
            Turrets.Add(turret);
            Debug.Log("Turret Registered! Total: " + Turrets.Count);
        }
    }

}
