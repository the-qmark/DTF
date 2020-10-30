using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private RoadSpawner roadSpawner;
    [SerializeField] private Resources resources;
    [Space]
    [SerializeField] private Building[] buildings;

    [SerializeField] private Vector2 pointForSpawn;

    private void OnEnable()
    {
        roadSpawner.PointReach += OnPointReached;
    }

    private void OnDisable()
    {
        roadSpawner.PointReach -= OnPointReached;
    }

    private void OnPointReached()
    {
        int index = Random.Range(0, buildings.Length);
        Building building = Instantiate(buildings[index], pointForSpawn, Quaternion.identity, transform);

        int chance = Random.Range(0, 100);

        if (chance <= 30)
        {
            building.SetState(BuildingState.Normal);
        }

        if (chance > 30 && chance < 60)
        {
            building.SetState(BuildingState.HP75);
        }

        if (chance >= 60)
        {
            building.SetState(BuildingState.HP50);
        }

        pointForSpawn += new Vector2(buildings[index].GetWidth() + Random.Range(0, 8), 0f);

        Destroy(building.gameObject, 60f);
    }
}
