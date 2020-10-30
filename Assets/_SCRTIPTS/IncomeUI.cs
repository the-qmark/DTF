using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class IncomeUI : MonoBehaviour
{
    [SerializeField] private Person target;
    [Space]
    [SerializeField] private TMP_Text textIncome;

    private void OnEnable()
    {
        target.IncomeChange += OnIncomeChanged;
    }

    private void OnDisable()
    {
        target.IncomeChange -= OnIncomeChanged;
    }


    private void Start()
    {
        textIncome.text = target.Income.ToIncome();
    }

    private void OnIncomeChanged()
    {
        textIncome.text = target.Income.ToIncome();
    }
}
public static class IncomeUIExtension
{
    public static string ToIncome(this float income)
    {
        return $"{income.ToString("F")}$/сек";
    }
}