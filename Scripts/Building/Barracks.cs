using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Building;
using HakoniwaCity.Job;
using HakoniwaCity.Ability;

public class Barracks : IBuilding, IJob
{
    private ObjectSpawnJob _job = null;
    private Action _onConstructionCompleted = null;

    private GameObject _buildingPrefab;
    private MeshRenderer _prefabMeshRenderer;
    private Vector3 _position;
    private Quaternion _rotation;

    public Barracks(float difficulty, GameObject buildingPrefab, Action onConstructionCompleted)
    {
        JobProgress jobProgress = new JobProgress(value: difficulty);
        _job = new ObjectSpawnJob(requiredProgress: jobProgress, targetObject: buildingPrefab, onCompleted: OnConstructionCompleted);

        _buildingPrefab = buildingPrefab;
        _prefabMeshRenderer = buildingPrefab.GetComponentInChildren<MeshRenderer>();
        _position = Vector3.zero;
    }

    private void OnConstructionCompleted()
    {
        if (_onConstructionCompleted == null)
        {
            Debug.LogWarning("_onConstructionCompleted is null");
        }
        else
        {
            _onConstructionCompleted();
        }
    }

    GameObject IBuilding.GetBuildingPrefab()
    {
        return _buildingPrefab;
    }

    MeshRenderer IBuilding.GetBuildingView()
    {
        return _prefabMeshRenderer;
    }

    Vector3 IBuilding.GetPosition()
    {
        return _position;
    }

    void IBuilding.SetPosition(Vector3 position)
    {
        _position = position; ;
    }

    Quaternion IBuilding.GetRotation()
    {
        return _rotation;
    }

    void IBuilding.SetRotation(Quaternion rotation)
    {
        _rotation = rotation;
    }

    AbilityKind[] IJob.GetRequiredResources()
    {
        return ((IJob)_job).GetRequiredResources();
    }

    JobStatus IJob.GetJobStatus()
    {
        return ((IJob)_job).GetJobStatus();
    }

    JobProgress IJob.GetJobProgress()
    {
        return ((IJob)_job).GetJobProgress();
    }

    void IJob.WorkOn(AbilityValue value)
    {
        ((IJob)_job).WorkOn(value);
    }

    Vector3 IJob.GetJobLocation()
    {
        return ((IJob)_job).GetJobLocation();
    }

    void IJob.SetJobLocation(Vector3 location)
    {
        ((IJob)_job).SetJobLocation(location);
    }

    string IJob.ToString()
    {
        return "Barracks";
    }
}
