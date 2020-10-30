using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Citizens : Person
{
    private static event UnityAction SadReaction;
    private static event UnityAction HappyReaction;

    [SerializeField] private AudioClip sadNoice;
    [SerializeField] private AudioClip happyNoice;

    private AudioSource audioSource;

    private void OnEnable()
    {
        SadReaction += SadMood;
        HappyReaction += HappyMood;
    }

    private void OnDisable()
    {
        SadReaction -= SadMood;
        HappyReaction -= HappyMood;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void CheapRepairReaction()
    {
        SadReaction?.Invoke();
    }

    public static void FullRepairReaction()
    {
        HappyReaction?.Invoke();
    }

    private void HappyMood()
    {
        ChangeMood(MoodType.Happy, 30);
        Scream(happyNoice);
    }

    private void SadMood()
    {
        ChangeMood(MoodType.Sad, 45);
        Scream(sadNoice);
    }

    private void Scream(AudioClip _audio)
    {
        audioSource.PlayOneShot(_audio);
    }
}

