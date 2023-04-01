using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBoxController : MonoBehaviour, IDamagable, Locomotable
{
    public Transform[] destinationList;
    private int destPoint = 0;
    private NavMeshAgent _agent;
    private bool _isLocomotion = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLocomotion)
        {
            if (_agent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
                    GotoNextPoint();
            }
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (destinationList.Length == 0)
        {
            _agent.isStopped = true;
            return;
        }

        if (_agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // Set the agent to go to the currently selected destination.
            _agent.destination = destinationList[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % destinationList.Length;
        }
    }

    public void OnDamage()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void SetWaypoints(Transform[] waypointList)
    {
        _agent = GetComponent<NavMeshAgent>();

        destinationList = waypointList;
        GotoNextPoint();
    }

    public void StartLocomote()
    {
        _isLocomotion = true;
    }
}
