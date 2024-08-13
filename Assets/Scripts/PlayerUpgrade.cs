using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] EnemyAutoShoot playerGun;
    [SerializeField] CurrencySystem currencySystem;
    [SerializeField] Image[] image;
    [SerializeField] Sprite sprites;
    [SerializeField] private int currentGunDamageLevel = 1;
    [SerializeField] private int currentGunFireLevel = 1;
    [SerializeField] private int maxGunDamageLevel = 4;  // Set the maximum gun level
    [SerializeField] private int maxGunFireLevel = 4;  // Set the maximum gun level
    [SerializeField] private int damage = 1;
    [SerializeField] private int upgradeDamageCost = 25;
    [SerializeField] private int upgradeFireCost = 25;

    // You might want to add UI elements to display the current gun level




    public void UpgradeGunDamage()
    {
        if (currentGunDamageLevel <= maxGunDamageLevel)
        {
            if (currencySystem.TotalCoins > upgradeDamageCost)
            {
                currencySystem.RemoveCoins(upgradeDamageCost);
                currentGunDamageLevel++;
                upgradeDamageCost += 25;
                UpdateGunDamageProperties();
                Debug.Log("Gun upgraded to level " + currentGunDamageLevel);
            }
        }
        else
        {
            Debug.Log("Maximum gun level reached!");
        }
    }

   public  void UpdateGunDamageProperties()
    {
        // Update attack properties based on the current gun level
        switch (currentGunDamageLevel)
        {
            case 1:
                playerGun.Damage = 1;
                
                break;
            case 2:
                image[0].sprite = sprites;
                playerGun.Damage = 2;
                break;
            case 3:
                image[1].sprite = sprites;
                playerGun.Damage = 3;
                break;
            case 4:
                image[2].sprite = sprites;
                playerGun.Damage = 4;
                break;
                // Add more cases for additional gun levels if needed
        }
    }
    public void UpgradeGunFireRate()
    {
        if (currentGunFireLevel <= maxGunFireLevel)
        {
            if (currencySystem.TotalCoins > upgradeFireCost)
            {
                currencySystem.RemoveCoins(upgradeFireCost);
                currentGunFireLevel++;
                upgradeFireCost += 25;
                UpdateGunFireRateProperties();
                Debug.Log("Gun upgraded to level " + currentGunFireLevel);
            }
        }
        else
        {
            Debug.Log("Maximum gun level reached!");
        }
    }

    public void UpdateGunFireRateProperties()
    {
        // Update attack properties based on the current gun level
        switch (currentGunFireLevel)
        {
            case 1:
                
                playerGun.shootingInterval = 1f;
                break;
            case 2:
                image[3].sprite = sprites;
                playerGun.shootingInterval = .8f;
                break;
            case 3:
                image[4].sprite = sprites;
                playerGun.shootingInterval = .6f;
                break;
            case 4:
                image[5].sprite = sprites;
                playerGun.shootingInterval = .5f;
                break;
                // Add more cases for additional gun levels if needed
        }
    }
}
