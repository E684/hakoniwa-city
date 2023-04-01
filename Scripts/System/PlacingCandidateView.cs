using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    public class PlacingCandidateView : IPrefabView
    {
        private GameObject _object;

        public PlacingCandidateView(GameObject prefab)
        {
            _object = GameObject.Instantiate(prefab);
        }

        public void HidePrefabView()
        {
            _object.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            _object.transform.position = position;
        }

        public void ShowPrefabView()
        {
            _object.SetActive(true);
        }
    }
}
