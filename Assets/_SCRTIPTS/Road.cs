using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Road : MonoBehaviour
{
    public event UnityAction TriggerReached;
    public float Width => GetComponent<SpriteRenderer>().bounds.size.x;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PresidentMovement president))
            TriggerReached?.Invoke();
    }
}