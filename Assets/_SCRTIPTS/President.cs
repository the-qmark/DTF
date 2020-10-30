using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class President : Person
{
    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Building building))
        {
            //Debug.Log(building.GetState());

            if (building.GetState() == BuildingState.FullRepair || building.GetState() == BuildingState.CheapRepair)
            {
                ChangeMood(MoodType.Happy, (int)building.GetState());
                //Debug.Log("!!!!");
            }
            
            if (building.GetState() == BuildingState.HP75 || building.GetState() == BuildingState.HP50)
            {
                ChangeMood(MoodType.Sad, (int)building.GetState());
                audioSource.Play();
                //Debug.Log("@@@@@");
            }

            building.DisableCollider();

            
        }

        //if (Mood <= 0)
        //    GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
    }
}
