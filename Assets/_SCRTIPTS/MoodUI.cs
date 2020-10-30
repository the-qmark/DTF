using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoodUI : MonoBehaviour
{
    [SerializeField] private Person targetPerson;
    [Space]
    [SerializeField] private Slider sliderMood;
    [SerializeField] private TMP_Text textMood;

    private void OnEnable()
    {
        targetPerson.MoodChange += OnMoodChanged;
    }

    private void OnDisable()
    {
        targetPerson.MoodChange -= OnMoodChanged;
    }

    private void OnMoodChanged(int moodDelta)
    {
        sliderMood.value += moodDelta;
        textMood.text = sliderMood.value.ToString();
    }

    void Start()
    {
        sliderMood.value = targetPerson.Mood;
        textMood.text = sliderMood.value.ToString();
    }
}
