using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //[SerializeField] private Road[] roads;
    [SerializeField] private Camera mainCamera;

    private float delta;
    //private Vector3 pointOnScreen = new Vector3();    

    //private int leftRoadIndex;
    //private int rightRoadIndex;

    public Queue<Road> roadsQueue = new Queue<Road>();

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Road _road))
            {
                roadsQueue.Enqueue(_road);
                _road.TriggerReached += OnTriggerReached;
            }
        }

        //foreach (var _road in roads)
        //{
        //    _road.TriggerReached += OnTriggerReached;
        //    roadsQueue.Enqueue(_road);
        //}
    }

    private void OnDisable()
    {
        //foreach (var _road in roads)
        //{
        //    _road.TriggerReached -= OnTriggerReached;
        //}

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Road _road))
            {
                _road.TriggerReached += OnTriggerReached;
            }
        }
    }

    void Start()
    {
        delta = roadsQueue.Peek().GetComponent<SpriteRenderer>().bounds.size.x;
        //leftRoadIndex = 0;
        //rightRoadIndex = roads.Length - 1;
    }
    

    private void OnTriggerReached()
    {
        //pointOnScreen = mainCamera.WorldToViewportPoint(roads[leftRoadIndex].transform.position);

        //if (pointOnScreen.x < 0)
        //{
        //    Vector2 _newPosition = new Vector2(roads[rightRoadIndex].transform.position.x + delta, roads[rightRoadIndex].transform.position.y);

        //    roads[leftRoadIndex].transform.position = _newPosition;

        //    leftRoadIndex.UpdateIndexBasedOn(roads);
        //    rightRoadIndex.UpdateIndexBasedOn(roads);

        //    return;
        //}

        Road _road = roadsQueue.Peek();
        Vector3 _pointOnScreen = mainCamera.WorldToViewportPoint(_road.transform.position);

        if (_pointOnScreen.x < 0) // если кусок дороги за областью видимости
        {
            Vector2 _newPosition = new Vector2(_road.transform.position.x + roadsQueue.Count * delta, _road.transform.position.y);
            _road.transform.position = _newPosition;

            roadsQueue.Enqueue(roadsQueue.Dequeue());
        }

    }
}

//public static class Index
//{
//    public static void UpdateIndexBasedOn(this ref int index, Road[] roads)
//    {
//        index = index >= roads.Length - 1 ? 0 : index + 1;
//    }
//}


