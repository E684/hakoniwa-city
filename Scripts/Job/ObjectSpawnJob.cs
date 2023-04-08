using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Ability;
using HakoniwaCity.Job;
using HakoniwaCity.Log;

public class ObjectSpawnJob : IJob
{
    private AbilityKind[] _requiredAbility;
    private JobProgress _requiredProgress;
    private JobProgress _currentProgress;
    private JobStatus _status;

    private GameObject _targetObject;
    private Vector3 _spawnPosition;
    private Action _onCompleted;

    public ObjectSpawnJob(JobProgress requiredProgress, GameObject targetObject, Action onCompleted)
    {
        _requiredAbility = new AbilityKind[]{
                    AbilityKind.OBJECT_SPAWN,
                };

        _requiredProgress = requiredProgress;
        _currentProgress.value = 0f;
        _status = JobStatus.NOT_STARTED;
        _targetObject = targetObject;
        _onCompleted = onCompleted;
    }

    private void UpdateStatus()
    {
        switch (_status)
        {
            case JobStatus.NOT_STARTED:
                if (_currentProgress.value >= _requiredProgress.value)
                {
                    Complete();
                }
                else if (_currentProgress.value > 0f)
                {
                    SetCurrentStatus(JobStatus.IN_PROGRESS);
                }
                break;
            case JobStatus.IN_PROGRESS:
                if (_currentProgress.value >= _requiredProgress.value)
                {
                    Complete();
                }
                break;
            case JobStatus.COMPLETE:
                /* no-op */
                break;
            default:
                Debug.LogError($"_status is wrong {_status}");
                break;
        }
    }
    private void Complete()
    {
        SetCurrentStatus(JobStatus.COMPLETE);
        Spawn();

        _onCompleted();
    }

    private void Spawn()
    {
        GameObject obj = GameObject.Instantiate(_targetObject);
        obj.transform.position = _spawnPosition;
    }

    Vector3 IJob.GetJobLocation()
    {
        return _targetObject.transform.position;
    }

    JobProgress IJob.GetJobProgress()
    {
        return _currentProgress;
    }

    JobStatus IJob.GetJobStatus()
    {
        return _status;
    }

    public void ResetJobStatus(){
        SetCurrentStatus(JobStatus.NOT_STARTED);
        SetCurrentProgress(0f);
    }

    AbilityKind[] IJob.GetRequiredResources()
    {
        return _requiredAbility;
    }

    void IJob.SetJobLocation(Vector3 location)
    {
        throw new System.NotImplementedException();
    }

    string IJob.ToString()
    {
        return "ObjectSpawnJob";
    }

    void IJob.WorkOn(AbilityValue value)
    {
        if (_status != JobStatus.COMPLETE)
        {
            SetCurrentProgress(_currentProgress.value + value.value);
            UpdateStatus();
        }
    }

    private void SetCurrentProgress(float value){
        _currentProgress.value = value;
    }
    private void SetCurrentStatus(JobStatus status){
        _status = status;
    }
}
