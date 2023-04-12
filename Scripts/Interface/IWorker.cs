using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HakoniwaCity.Job;
using HakoniwaCity.Ability;

namespace HakoniwaCity
{
    namespace Worker{
        public interface IWorker
        {
            public void Assign(AssignedJob item);
            public void DoWork();
            public bool IsAssigned();
            public AssignedJob GetAssignedJob();

            public List<IAbility> GetAbilities();

        }

        public interface IWorkerView
        {
            public IWorker GetWorker();
        }
    }
}
