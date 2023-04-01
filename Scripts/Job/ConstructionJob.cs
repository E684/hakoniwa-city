using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Ability;
using HakoniwaCity.Log;

namespace HakoniwaCity
{
    namespace Job
    {
        public class ConstructionJob : IJob
        {
            private AbilityKind[] _requiredAbility;
            private JobProgress _requiredProgress;
            private JobProgress _currentProgress;
            private JobStatus _status;

            private Transform _targetTransform;
            private Action _onCompleted;

            public ConstructionJob(JobProgress requiredProgress, GameObject targetObject, Action onCompleted)
            {
                _requiredAbility = new AbilityKind[]{
                    AbilityKind.CONSTRUCTION,
                };

                _requiredProgress = requiredProgress;
                _currentProgress.value = 0f;
                _status = JobStatus.NOT_STARTED;
                _targetTransform = targetObject.transform;
                _onCompleted = onCompleted;
            }

            public AbilityKind[] GetRequiredResources()
            {
                return _requiredAbility;
            }

            public JobStatus GetJobStatus()
            {
                return _status;
            }

            public void WorkOn(AbilityValue value)
            {
                HakoniwaLogger.Log($"ConstructionJob.WorkOn: _currentProgress.value = {_currentProgress.value}");
                if (_status != JobStatus.COMPLETE)
                {
                    _currentProgress.value = _currentProgress.value + value.value;
                    UpdateStatus();
                }
            }

            public string ToString()
            {
                return "ConstructionJob";
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
                            _status = JobStatus.IN_PROGRESS;
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
                _status = JobStatus.COMPLETE;
                _onCompleted();
            }

            public Vector3 GetJobLocation()
            {
                return _targetTransform.position;
            }
            public void SetJobLocation(Vector3 location)
            {
                _targetTransform.position = location;
            }

            public JobProgress GetJobProgress()
            {
                return _currentProgress;
            }

        }
    }
}


