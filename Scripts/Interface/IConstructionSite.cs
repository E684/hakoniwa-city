using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Job;

namespace HakoniwaCity
{
    namespace Building
    {
        public enum ConstructionSiteState
        {
            DEACTIVATE,
            ACTIVATE
        }

        public interface IConstructionSite
        {
            public GameObject GetConstructionSitePrefab();
            public MeshRenderer GetConstructionSiteView();
            public void SetOnConstructionCompletedAction(Action action);
            public IJob GetJob();

            public void SetPosition(Vector3 position);
            public Vector3 GetPosition();

            public void SetRotation(Quaternion rotation);
            public Quaternion GetRotation();
        }
    }
}
