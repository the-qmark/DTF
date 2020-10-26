using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    public event UnityAction TriggerReached;

    

    private void Start()
    {



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("roadroadroadroadroad");
        if (collision.TryGetComponent(out PresidentController president))
        {
            TriggerReached?.Invoke();
            //Debug.Log("road");
        }
    }
}
