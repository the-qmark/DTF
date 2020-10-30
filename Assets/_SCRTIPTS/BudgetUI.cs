using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BudgetUI : MonoBehaviour
{
    [SerializeField] private Budget budget;
    [SerializeField] private TMP_Text textBudget;

    private void OnEnable()
    {
        budget.BudgetChange += OnBudgetChange;
    }

    private void OnDisable()
    {
        budget.BudgetChange -= OnBudgetChange;
    }

    private void Start()
    {
        textBudget.text = budget.Value.ToBudget();
    }

    private void OnBudgetChange(float _value)
    {
        textBudget.text = _value.ToBudget();
    }
}
public static class BudgetUIExtension
{
    public static string ToBudget(this float budget)
    {
        return $"{budget.ToString("F")}$";
    }
}