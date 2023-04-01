using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Ability;
using HakoniwaCity.Character;
using HakoniwaCity.Log;

namespace HakoniwaCity
{
    namespace Job
    {
        public class JobMatch
        {
            public static bool Match(List<IAbility> abilities, IJob job, out AssignedJob assignedJob)
            {
                bool ret = true;
                IAbility usedAbility = null;

                AbilityKind[] requiredAbility = job.GetRequiredResources();
                foreach(AbilityKind req in requiredAbility)
                {
                    var found = abilities.Where(abl => abl.GetKind() == req);

                    HakoniwaLogger.Log($"JobMatch.Match: abilities={abilities}\nfound={found}");
                    if(found == null)
                    {
                        ret = false;
                        break;
                    }

                    usedAbility = found.DefaultIfEmpty(null).First();
                    if(usedAbility == null)
                    {
                        ret = false;
                        break;
                    }
                }

                if (ret)
                {
                    assignedJob = new AssignedJob(ref job, ref usedAbility);
                }
                else
                {
                    assignedJob = new AssignedJob();
                }

                return ret;
            }
            public static bool Match(IWorker worker, IJob job, out AssignedJob assignedJob)
            {
                List<IAbility> abilities = worker.GetAbilities();
                return Match(abilities, job, out assignedJob);
            }
            public static bool Match(ICitizen citizen, IJob job, out AssignedJob assignedJob)
            {
                IWorker worker = citizen.GetWorker();
                return Match(worker, job, out assignedJob);
            }

        }

        public class AssignedJob
        {
            private IAbility _ability;
            private IJob _job;

            public AssignedJob()
            {
                _ability = null;
                _job = null;
            }
            public AssignedJob(ref IJob job, ref IAbility ability)
            {
                _ability = ability;
                _job = job;
            }

            public void WorkOn()
            {
                _job.WorkOn(_ability.GetValue());
            }

            public JobStatus GetJobStatus()
            {
                if (_job == null) return JobStatus.COMPLETE;

                return _job.GetJobStatus();
            }

            public Vector3 GetJobLocation()
            {
                return _job.GetJobLocation();
            }

            public bool IsCompleted()
            {
                return _job.GetJobStatus() == JobStatus.COMPLETE;
            }
        }
    }
}
