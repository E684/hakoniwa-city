using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Log;
using HakoniwaCity.Job;

public class WorkerOperator : IWorker
{
    private List<IAbility> _abilities = new List<IAbility>();
    private AssignedJob _assignedJob;
    private Transform _transform;

    private const float _workableDistance = 1f;

    public WorkerOperator(Transform transform, List<IAbility> abilities)
    {
        _transform = transform;
        _abilities = abilities;
        _assignedJob = null;
    }

    ////////////////IWorker
    public void Assign(AssignedJob item)
    {
        HakoniwaLogger.Log($"Worker.Assign: {item} ");
        _assignedJob = item;
    }

    public void DoWork()
    {
        if (_assignedJob == null) return;

        if (IsNearJobTarget())
        {
            HakoniwaLogger.Log($"DoWork");
            _assignedJob.WorkOn();
        }
        else
        {
            HakoniwaLogger.Log($"[{this.ToString()}]Worker is far from job target {_assignedJob.GetJobLocation()}");
            //nop
        }

        if (_assignedJob.IsCompleted())
        {
            _assignedJob = null;
        }
    }

    public List<IAbility> GetAbilities()
    {
        return _abilities;
    }
    public bool IsAssigned()
    {
        bool ret = _assignedJob != null;
        return ret;
    }
    public AssignedJob GetAssignedJob()
    {
        return _assignedJob;
    }


    private bool IsNearJobTarget()
    {
        float distance = (_transform.position - _assignedJob.GetJobLocation()).magnitude;
        return distance < _workableDistance;
    }
}
