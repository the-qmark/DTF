using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mood : MonoBehaviour
{
    public event UnityAction<Object, int> MoodChange;

    private float mood = 60; // от 0 до 100

    public void ChangeMood(MoodType moodType)
    {
        int moodDelta = Random.Range(5, 15) * (int)moodType; // на сколько изменится настроение

        mood += moodDelta;
        mood = Mathf.Clamp(mood, 0, 100);

        MoodChange?.Invoke(this, moodDelta);

        Debug.Log("MOOD = " + mood);


        if (mood <= 0)
        {
            // GAME OVER
        }
    }
}

public enum MoodType
{
    Happy = 1,
    Sad = -1
}