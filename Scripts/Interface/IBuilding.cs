using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Building
    {
        public enum BuildingState
        {
            DEACTIVATE,
            ACTIVATE
        }

        public interface IBuilding
        {
            public GameObject GetBuildingPrefab();
            public MeshRenderer GetBuildingView();
            public void SetPosition(Vector3 position);
            public Vector3 GetPosition();
            public void SetRotation(Quaternion rotation);
            public Quaternion GetRotation();

        }

        public interface IBuildingView
        {
            public IBuilding GetBuilding();
        }
    }
}
