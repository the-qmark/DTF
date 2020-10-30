//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
//using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Building : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hp100;
    [Space]
    [SerializeField] private SpriteRenderer hp75;
    [SerializeField] private SpriteRenderer hp75Repair;
    [Space]
    [SerializeField] private SpriteRenderer hp50;
    [SerializeField] private SpriteRenderer hp50Repair;
    [Space]
    [SerializeField] private RepairPanel repairPanel;

    public float CheapCost => cheapCost;
    public float FullRepairCost => fullRepairCost;

    private float cheapCost;
    private float fullRepairCost;

    private BuildingState state;

    private void OnMouseDown()
    {
        if (state == BuildingState.HP75 || state == BuildingState.HP50)
            repairPanel.gameObject.SetActive(true);
    }

    public BuildingState GetState()
    {
        return state;
    }

    public void SetState(BuildingState _state)
    {
        state = _state;

        switch (state) // TODO: попытаться избавиться от всех этих свитчей, мб как-то все в общий метод запихнуть?
        {
            case BuildingState.Normal:
                hp100.gameObject.SetActive(true);
                DisableCollider();
                break;
            case BuildingState.HP75:
                cheapCost = Random.Range(40, 60);
                fullRepairCost = Random.Range(60, 80);
                hp75.gameObject.SetActive(true);
                break;
            case BuildingState.HP50:
                cheapCost = Random.Range(60, 80);
                fullRepairCost = Random.Range(80, 120);
                hp50.gameObject.SetActive(true);
                break;
            default:
                break;
        } 
    }

    public void CheapRepair()
    {
        switch (state)
        {
            case BuildingState.HP75:
                hp75Repair.gameObject.SetActive(true);
                hp75.gameObject.SetActive(false);
                break;
            case BuildingState.HP50:
                hp50Repair.gameObject.SetActive(true);
                hp50.gameObject.SetActive(false);
                break;
        }

        state = BuildingState.CheapRepair;

        Citizens.CheapRepairReaction();
    }

    public void FullRepair()
    {
        switch (state)
        {
            case BuildingState.HP75:
                hp75.gameObject.SetActive(false);
                break;
            case BuildingState.HP50:
                hp50.gameObject.SetActive(false);
                break;
        }

        state = BuildingState.FullRepair;
        hp100.gameObject.SetActive(true);

        Citizens.FullRepairReaction();
    }

    public float GetWidth()
    {
        return hp100.bounds.size.x;
    }

    public void DisableCollider()
    {
        TryGetComponent(out BoxCollider2D boxCollider2D);
        boxCollider2D.enabled = false;
    }
}
public enum BuildingState
{
    Normal = 0,
    HP75 = 27,
    HP50 = 39,
    CheapRepair = 25,
    FullRepair = 35
}
