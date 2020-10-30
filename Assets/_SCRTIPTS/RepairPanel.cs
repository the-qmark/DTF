using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairPanel : MonoBehaviour
{
    [SerializeField] private Building building;
    [Space]
    [SerializeField] private Button buttonCheap;
    [SerializeField] private Button buttonFullRepair;

    public Budget budget;

    private void OnEnable()
    {
        budget = Budget.GetInit();
        budget.BudgetChange += OnBudgetChanged;
    }

    private void OnDisable()
    {
        budget.BudgetChange -= OnBudgetChanged;
    }

    void Start()
    {
        if (buttonCheap.transform.GetChild(0).TryGetComponent(out TMP_Text textCheap))
            textCheap.text = building.CheapCost.ToString() + "$";

        if (buttonFullRepair.transform.GetChild(0).TryGetComponent(out TMP_Text textFull))
            textFull.text = building.FullRepairCost.ToString() + "$";

        CheckBudget(budget.Value);
        
    }

    public void OnBudgetChanged(float _value)
    {
        CheckBudget(_value);
        //Debug.Log("+++");
    }

    private void CheckBudget(float _value)
    {
        buttonCheap.interactable = (_value >= building.CheapCost);
        buttonFullRepair.interactable = (_value >= building.FullRepairCost);
    }

    public void CheapCost()
    {
        if (budget.BuyIfCan(building.CheapCost))
            building.CheapRepair();
    }

    public void FullCost()
    {
        if (budget.BuyIfCan(building.FullRepairCost))
            building.FullRepair();
    }


}
