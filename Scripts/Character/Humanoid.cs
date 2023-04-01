using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using HakoniwaCity.Character;

public class Humanoid : ICharacter
{
    private NavMeshAgent _agent;
    private Transform _transform;

    const float _nearThreshold = 1f;

    public Humanoid(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public void Communicate()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector3 destination)
    {
        if (IsNearDestination(destination))
        {
            EnableNavMeshAgent(false);
        }
        else
        {
            EnableNavMeshAgent(true);
            _agent.destination = destination;
        }
    }

    private bool IsNearDestination(Vector3 destination)
    {
        float distance = (_transform.position - destination).magnitude;

        return distance < _nearThreshold;
    }

    private void EnableNavMeshAgent(bool value)
    {
        _agent.enabled = value;
    }
}
