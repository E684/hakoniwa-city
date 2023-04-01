using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWayPointLocomotion
{
    private Queue<Vector3> _waypoints;
    private Vector3 _currentDestination;
    private float _minDistanceToApproach = 0.1f;

    public SimpleWayPointLocomotion(Queue<Vector3> waypoints)
    {
        _waypoints = waypoints;

        if(Length() > 0)
        {
            _currentDestination = GetNextWayPoint();
        }
        else
        {
            _currentDestination = Vector3.zero;
        }
    }

    private Vector3 GetNextWayPoint()
    {
        return _waypoints.Dequeue();
    }

    private int Length()
    {
        return _waypoints.Count;
    }

    private bool IsReach(Vector3 vector)
    {
        return vector.magnitude < _minDistanceToApproach;
    }

    public Vector3 CalcDistance(Vector3 currentPosition)
    {
        return currentPosition - _currentDestination;
    }

}
