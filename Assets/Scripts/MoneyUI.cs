using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text _moneyAmountText;
    public static int MoneyAmount;

    private void Start() => Money.onMoneyAmountChange += OnMoneyAmountChanged;

    private void OnMoneyAmountChanged(int newMoneyAmount)
    {
        MoneyAmount = newMoneyAmount;
        _moneyAmountText.text = newMoneyAmount.ToString();
    }
}
