using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private int coinTest;
    private string Currency_Save_Key;
    [SerializeField] private TextMeshProUGUI currentCoin;
    public int TotalCoins { get; private set; }

    private void Start()
    {
        PlayerPrefs.DeleteKey(Currency_Save_Key);
        LoadCoins();
    }

    private void Update()
    {
        currentCoin.text = TotalCoins.ToString();
    }

    private void LoadCoins()
    {
        TotalCoins = PlayerPrefs.GetInt(Currency_Save_Key,coinTest);
    }

    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        PlayerPrefs.SetInt(Currency_Save_Key,TotalCoins);
        PlayerPrefs.Save();
    }

    private void AddCoins(EnemyAi enemy)
    {
        AddCoins(EnemyAi.CointAtDeath);
    }

    public void RemoveCoins(int amount)
    {
        TotalCoins -= amount;
        PlayerPrefs.SetInt(Currency_Save_Key, TotalCoins);
        PlayerPrefs.Save();
    }
}
