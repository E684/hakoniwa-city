using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HakoniwaCity.Ability;

namespace HakoniwaCity
{
    namespace Job
    {
        public interface IJob
        {
            public AbilityKind[] GetRequiredResources();
            public JobStatus GetJobStatus();
            public void ResetJobStatus();
            public JobProgress GetJobProgress();
            public void WorkOn(AbilityValue value);

            public Vector3 GetJobLocation();
            public void SetJobLocation(Vector3 location);
            public string ToString();
        }
        public interface IJobView
        {
            public IJob GetJob();
        }

        public enum JobStatus
        {
            NOT_STARTED,
            IN_PROGRESS,
            COMPLETE
        }

        public struct JobProgress
        {
            public JobProgress(float value)
            {
                this.value = value;
            }

            public float value;
        }

        public struct JobValue
        {
            public float value;
        }

    }
}
