using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Building;
using HakoniwaCity.Log;
using HakoniwaCity.Job;

public class ConstructionSite : IConstructionSite, IJob, IPrefabView
{
    private ConstructionJob _job = null;
    private MeshRenderer _prefabMeshRenderer;
    private GameObject _prefab;
    private Vector3 _position;
    private Quaternion _rotation;
    private Action _onConstructionCompleted = null;

    public ConstructionSite(float difficulty, GameObject prefab, Action onConstructionCompleted)
    {
        JobProgress jobProgress = new JobProgress(value: difficulty);
        _job = new ConstructionJob(requiredProgress: jobProgress, targetObject: prefab, onCompleted: OnConstructionCompleted);
        _prefab = prefab;
        _prefabMeshRenderer = prefab.GetComponentInChildren<MeshRenderer>();
        _position = Vector3.zero;
        _onConstructionCompleted = onConstructionCompleted;
    }

    private void OnConstructionCompleted()
    {
        if(_onConstructionCompleted == null)
        {
            Debug.LogWarning("_onConstructionCompleted is null");
        }
        else
        {
            _onConstructionCompleted();
        }
    }

    /////////////////IConstructionSite
    public GameObject GetConstructionSitePrefab()
    {
        return _prefab;
    }

    public MeshRenderer GetConstructionSiteView()
    {
        return _prefabMeshRenderer;
    }

    public void SetOnConstructionCompletedAction(Action action)
    {
        _onConstructionCompleted = action;
    }
    public IJob GetJob()
    {
        return _job;
    }

    public void SetPosition(Vector3 position)
    {
        _position = position;
    }

    public Vector3 GetPosition()
    {
        return _position;
    }

    public void SetRotation(Quaternion rotation)
    {
        _rotation = rotation;
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }
    /////////////////IJob
    public Vector3 GetJobLocation()
    {
        return _job.GetJobLocation();
    }
    public void SetJobLocation(Vector3 location)
    {
        ((IJob)_job).SetJobLocation(location);
    }

    public JobProgress GetJobProgress()
    {
        return _job.GetJobProgress();
    }

    public AbilityKind[] GetRequiredResources()
    {
        return _job.GetRequiredResources();
    }

    public JobStatus GetJobStatus()
    {
        return _job.GetJobStatus();
    }

    public void ResetJobStatus(){
        _job.ResetJobStatus();
    }

    public void WorkOn(AbilityValue value)
    {
        HakoniwaLogger.Log($"ConstructionSite WorkOn");
        _job.WorkOn(value);
    }

    /////////////////IPrefabView
    public void HidePrefabView()
    {
        throw new NotImplementedException();
    }

    public void ShowPrefabView()
    {
        throw new NotImplementedException();
    }

}
