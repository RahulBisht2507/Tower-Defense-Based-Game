using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretImplement : MonoBehaviour
{
    private CurrencySystem currencySystem;
    [SerializeField]private int turretCost;
    [SerializeField] private Turret turret;
    [SerializeField] public bool turretImplemented;
    [SerializeField] public TurretUpgradeSystem upgradeSystem;
    [SerializeField] private Animator cube;
    [SerializeField] private Transform move;
    [SerializeField] private Transform turrettransform;
    private void Awake()
    {
        currencySystem = FindFirstObjectByType<CurrencySystem>();
    }
    private void Move(Vector3 pos)
    {
        Vector3 newpos = Vector3.Lerp(turrettransform.transform.position, pos, 10f * Time.deltaTime);
        turrettransform.transform.position = newpos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currencySystem.TotalCoins >= turretCost)
        {
            if (other.CompareTag("Player") && !turretImplemented)
            {
                turretImplemented = true;
                currencySystem.RemoveCoins(turretCost);
                turret.enabled = true;
            }
            if(turretImplemented && currencySystem.TotalCoins >= upgradeSystem.currentUpgradCost && upgradeSystem.currentUpgradeLevel <upgradeSystem.maxUpgradeLevel)
            {
                upgradeSystem.UpgradeTurret();
                currencySystem.RemoveCoins(upgradeSystem.currentUpgradCost);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Move(move.position);
        }
    }

}
