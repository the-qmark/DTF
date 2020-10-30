using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Budget : MonoBehaviour
{
    [SerializeField] private Person[] incomeTargets;

    public event UnityAction<float> BudgetChange;

    public float Value => budget;

    private static Budget instance;
    private float budget;
    private float allIncome;


    private void OnEnable()
    {
        foreach (var target in incomeTargets)
        {
            target.IncomeChange += OnIncomeChanged;
        }
    }

    private void OnDisable()
    {
        foreach (var target in incomeTargets)
        {
            target.IncomeChange -= OnIncomeChanged;
        }
    }

    public static Budget GetInit()
    {
        //if (instance == null)
        //    instance = new Budget();
        return instance;
    }

    private void Awake()
    {
        instance = this;
        budget = Random.Range(70f, 150f);
    }

    private void Start()
    {
        OnIncomeChanged();
    }

    public void StartGame()
    {
        StartCoroutine(Income());
    }

    public bool BuyIfCan(float _cost)
    {
        if (_cost <= budget)
        {
            budget -= _cost;
            BudgetChange?.Invoke(budget);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnIncomeChanged()
    {
        allIncome = 0;
        foreach (var target in incomeTargets)
            allIncome += target.Income;
    }

    private IEnumerator Income()
    {
        WaitForSeconds oneSec = new WaitForSeconds(1f);
        while (true)
        {
            budget += allIncome;
            budget = Mathf.Clamp(budget, 0f, 2000f);
            //Debug.Log("all " + allIncome);
            BudgetChange?.Invoke(budget);
            yield return oneSec;
        }
    }
}
