using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{
    [SerializeField] private float maxIncome;

    public event UnityAction<int> MoodChange;
    public event UnityAction IncomeChange;

    public int Mood => mood;
    public float Income => income;

    protected int mood;
    protected float income;

    private void Awake()
    {
        mood = Random.Range(40, 70);
        income = Random.Range(3f, maxIncome / 3);
    }

    public void ChangeMood(MoodType _moodType, int _seriousness) // от "серьезности" зависит количество полученного/утраченного настроения
    {

        int _moodDelta = Random.Range(_seriousness / 3, _seriousness) * (int)_moodType; // на сколько изменится настроение
        //Debug.Log("delta " + _moodDelta + "   "  + this.name);

        mood += _moodDelta;
        mood = Mathf.Clamp(mood, 0, 100);

        if (mood <= 0)
            Game.GameIsOver();

        MoodChange?.Invoke(_moodDelta);

        ChangeIncome(_moodDelta);
    }

    private void ChangeIncome(float _moodDelta)
    {
        float _incomeDelta = (float)(_moodDelta * 30) / 100; // 30% от измененного настроения 
        income += _incomeDelta;
        income = Mathf.Clamp(income, 3f, maxIncome);
        IncomeChange?.Invoke();
    }
}

public enum MoodType
{
    Happy = 1,
    Sad = -1
}