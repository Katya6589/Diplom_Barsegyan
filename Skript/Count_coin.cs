using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count_coin : MonoBehaviour
{
    public int _numderOfCoins;
    [SerializeField] private TextMeshProUGUI _text;


    public void Start()
    {
        _numderOfCoins = Progress.Instance.Coins;
        _text.text = _numderOfCoins.ToString();

    }

    public void AddOne()
    {
        _numderOfCoins += 1;
        _text.text = _numderOfCoins.ToString();

    }


    public void SaveToProgress()
    {
        Progress.Instance.Coins = _numderOfCoins;
    }

    public void SpendMoney(int value)
    {
        _numderOfCoins -= value;
        _text.text = _numderOfCoins.ToString();

    }
}
