using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    public interface IPrefabView
    {
        public void ShowPrefabView();
        public void HidePrefabView();
        public void SetPosition(Vector3 position);
    }
}
