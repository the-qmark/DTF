using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Resources : MonoBehaviour
{
    public event UnityAction<int> BudgetChange;
    public event UnityAction<int, int> IncomeChange;
    
    [SerializeField] private President president;
    [SerializeField] private Citizens citizens;

    private int budget = 200;
    private int presidentIncome = 20;
    private int citizensIncome = 10;

    private void OnEnable()
    {
        president.MoodChange += OnMoodChange;
        citizens.MoodChange += OnMoodChange;
    }

    private void OnDisable()
    {
        president.MoodChange -= OnMoodChange;
        citizens.MoodChange -= OnMoodChange;
    }

    private void Start()
    {
        BudgetChange?.Invoke(budget);
        IncomeChange?.Invoke(presidentIncome, citizensIncome);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            president.ChangeMood(MoodType.Happy);
            citizens.ChangeMood(MoodType.Sad);
        }
    }

    public void GameStart()
    {
        StartCoroutine(Income());
    }

    public void OnMoodChange(Object sender, int moodDelta)
    {
        if (sender is President)
            ChangeIncome(ref presidentIncome, moodDelta);

        if (sender is Citizens)
            ChangeIncome(ref citizensIncome, moodDelta);

        IncomeChange?.Invoke(presidentIncome, citizensIncome);
    }

    public void ChangeIncome(ref int income, int moodDelta)
    {
        income += (moodDelta / 5) * Random.Range(1, 5);
        income = Mathf.Clamp(income, 0, 999);  
    }

    private IEnumerator Income()
    {
        WaitForSeconds oneSecond = new WaitForSeconds(1f);
        while (true)
        {
            budget += presidentIncome + citizensIncome;
            BudgetChange?.Invoke(budget);

            yield return oneSecond;
        }
    }
}
