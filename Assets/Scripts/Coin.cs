using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CurrencySystem currency;
    private void Awake()
    {
        currency = FindAnyObjectByType<CurrencySystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currency.AddCoins(25);
            Destroy(gameObject);
        }
    }
}
