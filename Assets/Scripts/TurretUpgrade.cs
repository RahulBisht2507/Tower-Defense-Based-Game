using TMPro;
using UnityEngine;

public class TurretUpgradeSystem : MonoBehaviour
{
    [SerializeField]public int maxUpgradeLevel = 3; // Maximum upgrade level
    [SerializeField]public int currentUpgradeLevel = 1; // Current upgrade level
     public int currentUpgradCost = 50;

    // Define upgrade parameters (you can expand this based on your game's mechanics)
    [SerializeField] private int[] damageLevels = { 1, 2, 3 }; // Example: Damage levels for each upgrade
    [SerializeField] private float[] fireRateLevels = { 1f, 0.8f, 0.6f }; // Example: Fire rate levels for each upgrade

    [SerializeField] private Transform turretHead; // Reference to the turret head
    [SerializeField] private TextMeshProUGUI upgradetext;
    [SerializeField] private TurretImplement TI;
    void Update()
    {
        // Example: Check for player input to upgrade the turret
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpgradeTurret();
        }
        if (TI.turretImplemented)
        {
            upgradetext.text = currentUpgradCost.ToString();
        }


    }

    public void UpgradeTurret()
    {
        if (currentUpgradeLevel < maxUpgradeLevel)
        {
            // Increase upgrade level
            currentUpgradeLevel++;
            currentUpgradCost += 25;
            upgradetext.text = currentUpgradCost.ToString();
            // Apply upgrade parameters based on the current upgrade level
            ApplyUpgrade();

            Debug.Log("Turret Upgraded to Level " + currentUpgradeLevel);
        }
        else
        {
            Debug.Log("Turret already at maximum upgrade level");
        }
    }

    void ApplyUpgrade()
    {
        // Example: Apply the upgrade parameters to the turret
        if (turretHead != null)
        {
             
            // Example: Increase damage and fire rate based on the current upgrade level
            Turret turret = turretHead.GetComponent<Turret>();
            turret.turretDamage = damageLevels[currentUpgradeLevel - 1];
            /*if (turret != null)
            {
                turret.turretDamage = damageLevels[currentUpgradeLevel - 1];
                turret.fireRate = fireRateLevels[currentUpgradeLevel - 1];
            }
*/
            // You can add more upgrade parameters based on your game's mechanics
        }
    }
}
