using System;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Building;
using HakoniwaCity.Job;

public class HM_House : MonoBehaviour, IHakoniwaObject, ISite, IJobView, IWorker
{
    private IConstructionSite _constructionSite = null;
    public GameObject constructionSitePrefab;
    public float constructionDifficulty = 50f;

    private IBuilding _building;
    public GameObject buildingPrefab;

    private bool _isInitialized = false;
    private SiteStatus _siteStatus;

    private HM_HouseGameLogic _HouseOperator;
    private Action _onConstructionCompleted = null;


    public void Update()
    {
        // no-op
    }

    private void OnConstructionCompleted()
    {
        Debug.Log("OnConstructionCompleted");
        if(_onConstructionCompleted != null)
        {
            _onConstructionCompleted();
        }
        else
        {
            Debug.LogWarning("_onConstructionCompleted is null");
        }
    }

    ////////////////////////////IHakoniwaObject
    public void InitializeObject()
    {
        _constructionSite = new ConstructionSite(difficulty: constructionDifficulty,
                                                prefab: constructionSitePrefab,
                                                onConstructionCompleted: () => { OnConstructionCompleted(); });

        _building = new Building(buildingPrefab);

        _isInitialized = true;
        _siteStatus = SiteStatus.PLACED;
    }

    public bool IsInitialized()
    {
        return _isInitialized;
    }


    public void Action()
    {
        switch (_siteStatus)
        {
            case SiteStatus.PLACED:
                if (_constructionSite.GetJob().GetJobStatus() == JobStatus.IN_PROGRESS)
                {
                    _siteStatus = SiteStatus.UNDER_CONSTRUCTION;
                }
                break;
            case SiteStatus.UNDER_CONSTRUCTION:
                if(_constructionSite.GetJob().GetJobStatus() == JobStatus.COMPLETE)
                {
                    _siteStatus = SiteStatus.BUILT;
                }
                break;
            case SiteStatus.BUILT:
                break;
            case SiteStatus.DISSOLUTION:
                break;
            default:
                Debug.LogError($"_siteStatus is invalid {_siteStatus}");
                break;
        }
    }

    ////////////////////////////ISite
    public IBuilding GetBuilding()
    {
        return _building;
    }
    public IConstructionSite GetConstructionSite()
    {
        return _constructionSite;
    }

    public SiteStatus GetSiteStatus()
    {
        return _siteStatus;
    }
    public void SetOnConstructionCompletedAction(Action action)
    {
        if(_constructionSite == null)
        {
            Debug.LogWarning("_constructionSite is null");
        }
        else
        {
            _constructionSite.SetOnConstructionCompletedAction(action);
        }
    }

    ////////////////////////////IJobView
    public IJob GetJob()
    {
        return _constructionSite.GetJob();
    }

    ////////////////////////////IWorker
    public void Assign(AssignedJob item)
    {
        throw new System.NotImplementedException();
    }

    public void DoWork()
    {
        throw new System.NotImplementedException();
    }

    public IAbility[] GetAbilities()
    {
        throw new System.NotImplementedException();
    }

    List<IAbility> IWorker.GetAbilities()
    {
        throw new System.NotImplementedException();
    }

    public bool IsAssigned()
    {
        throw new System.NotImplementedException();
    }

    public AssignedJob GetAssignedJob()
    {
        throw new System.NotImplementedException();
    }

}
