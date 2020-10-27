using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private Resources resources;
    [Space]
    [SerializeField] private TMP_Text budgetText;
    [SerializeField] private TMP_Text presidentIncomeText;
    [SerializeField] private TMP_Text citizensIncomeText;

    private void OnEnable()
    {
        resources.BudgetChange += OnBudgetChanged;
        resources.IncomeChange += OnIncomeChanged;
    }

    private void OnDisable()
    {
        resources.BudgetChange -= OnBudgetChanged;
        resources.IncomeChange += OnIncomeChanged;
    }


    private void OnBudgetChanged(int budget)
    {
        budgetText.text = budget.ToString();
    }

    private void OnIncomeChanged(int president, int citizens)
    {
        presidentIncomeText.text = president.ToIncome();
        citizensIncomeText.text = citizens.ToIncome();
    }
}

public static class Inc
{
    public static string ToIncome(this int income)
    {
        return $"{income}$/сек";
    }
}
