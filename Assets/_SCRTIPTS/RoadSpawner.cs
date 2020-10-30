using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    public event UnityAction PointReach;

    [SerializeField] private Camera mainCamera;

    private Queue<Road> roadsQueue = new Queue<Road>();
    private float delta;

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
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).TryGetComponent(out Road _road))
                _road.TriggerReached -= OnTriggerReached;
    }

    void Start()
    {
        delta = roadsQueue.Peek().Width;
    }

    private void OnTriggerReached()
    {
        Road _road = roadsQueue.Peek();
        Vector3 _pointOnScreen = mainCamera.WorldToViewportPoint(_road.transform.position);

        if (_pointOnScreen.x < 0)
        {
            Vector2 _newPosition = new Vector2(_road.transform.position.x + roadsQueue.Count * delta, _road.transform.position.y);
            _road.transform.position = _newPosition;
            roadsQueue.Enqueue(roadsQueue.Dequeue());
        }

        PointReach?.Invoke();
    }
}