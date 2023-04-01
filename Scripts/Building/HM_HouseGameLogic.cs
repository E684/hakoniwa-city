using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Job;
using HakoniwaCity.Log;

namespace HakoniwaCity
{
    namespace Building
    {
        public class HM_HouseGameLogic
        {
            private enum HM_HouseGameLogicState
            {
                HOUSE_CONSTRUCTION_SELECTED,
                HOUSE_CONSTRUCTION_PLACED,
                HOUSE_CONSTRUCTION_COMPLETED,

            }

            private IJobView _jobView = null;
            private IHakoniwaObject _hakoniwaObject = null;
            private ISite _site = null;

            private IConstructionSite _constructionSite = null;
            private GameObject _constructionSiteObject = null;

            private IBuilding _building = null;
            private GameObject _buildingObject = null;

            private HM_HouseGameLogicState _currentState;

            private MeshRenderer _currentRenderer;
            
            public HM_HouseGameLogic(){}

            public bool Initialize(GameObject constructionSiteObj, Action onConstructionCompleted)
            {
                _jobView = constructionSiteObj.GetComponent<IJobView>();
                if (_jobView == null) return false;

                _hakoniwaObject = constructionSiteObj.GetComponent<IHakoniwaObject>();
                if (_hakoniwaObject == null) return false;

                _hakoniwaObject.InitializeObject();
                if (!_hakoniwaObject.IsInitialized()) return false;

                _site = constructionSiteObj.GetComponent<ISite>();
                if (_site == null) return false;
                _site.SetOnConstructionCompletedAction(onConstructionCompleted);

                _constructionSite = _site.GetConstructionSite();
                if (_constructionSite == null) return false;
                _constructionSiteObject = GameObject.Instantiate(_constructionSite.GetConstructionSitePrefab());
                GameObject.Destroy(_constructionSiteObject.GetComponent<Collider>());
                _constructionSiteObject.SetActive(false);

                _building = _site.GetBuilding();
                if (_building == null) return false;

                _currentState = HM_HouseGameLogicState.HOUSE_CONSTRUCTION_SELECTED;

                return true;
            }

            public bool Initialize(GameObject obj)
            {
                Action onConstructionCompleted = () => { Debug.Log("onConstructionCompleted is No-op"); };

                return Initialize(obj, OnConstructionCompleted);
            }

            public void ShowConstructionSiteCandidate(Camera camera, Vector2 point)
            {
                if (_currentState != HM_HouseGameLogicState.HOUSE_CONSTRUCTION_SELECTED)
                    return;

                // ConstructionSiteのInstantiateがされていない

                Ray ray = camera.ScreenPointToRay(point);
                _currentRenderer = _constructionSite.GetConstructionSiteView();

                // あらゆる地形（rigidbodyにヒットするためmask必要）
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _constructionSiteObject.SetActive(true);
                    _constructionSiteObject.transform.position = hit.point;
                    _constructionSiteObject.transform.rotation = Quaternion.identity;

                    _currentRenderer.enabled = true;
                }
                else
                {
                    _constructionSiteObject.SetActive(false);
                    _currentRenderer.enabled = false;
                }
            }

            public bool PutConstructionSite(Camera camera, Vector2 point)
            {
                if (_currentState != HM_HouseGameLogicState.HOUSE_CONSTRUCTION_SELECTED)
                    return false;

                bool ret = false;
                Ray ray = camera.ScreenPointToRay(point);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _constructionSite.SetPosition(hit.point);
                    _constructionSite.SetRotation(Quaternion.identity);

                    _constructionSiteObject.transform.position = _constructionSite.GetPosition();
                    _constructionSiteObject.transform.rotation = _constructionSite.GetRotation();

                    _jobView.GetJob().SetJobLocation(hit.point);


                    _currentState = HM_HouseGameLogicState.HOUSE_CONSTRUCTION_PLACED;
                    ret = true;
                }

                return ret;
            }

            private void RemoveConstructionSite()
            {
                if (_constructionSiteObject == null) return;

                GameObject.Destroy(_constructionSiteObject);
            }

            public void AssignJob(IWorker worker)
            {
                IJob job = _jobView.GetJob();
                AssignedJob assignedJob;
                JobMatch.Match(worker, job, out assignedJob);

                worker.Assign(assignedJob);
            }

            private void PutBuilding()
            {
                _building.SetPosition(_constructionSite.GetPosition());
                _building.SetRotation(_constructionSite.GetRotation());

                _buildingObject = GameObject.Instantiate(_building.GetBuildingPrefab());
                _buildingObject.transform.position = _building.GetPosition();
                _buildingObject.transform.rotation = _building.GetRotation();
            }

            private void ShowBuilding()
            {
                _currentRenderer = _building.GetBuildingView();
                _currentRenderer.enabled = true;
                _building.SetPosition(_constructionSite.GetPosition());
            }

            private void OnConstructionCompleted()
            {
                _currentState = HM_HouseGameLogicState.HOUSE_CONSTRUCTION_COMPLETED;

                PutBuilding();
                ShowBuilding();

                RemoveConstructionSite();
            }
        }
    }
}
