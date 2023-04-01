using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Building;
using HakoniwaCity.Job;
using System;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Building;
using HakoniwaCity.Job;


public class RedKnightBarracks : MonoBehaviour, IHakoniwaObject, ISite, IJobView, IWorker
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
        if (_onConstructionCompleted != null)
        {
            _onConstructionCompleted();
        }
        else
        {
            Debug.LogWarning("_onConstructionCompleted is null");
        }
    }

    void IHakoniwaObject.Action()
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
                if (_constructionSite.GetJob().GetJobStatus() == JobStatus.COMPLETE)
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
    void IHakoniwaObject.InitializeObject()
    {
        _constructionSite = new ConstructionSite(difficulty: constructionDifficulty,
                                                prefab: constructionSitePrefab,
                                                onConstructionCompleted: () => { OnConstructionCompleted(); });

        _building = new Building(buildingPrefab);

        _isInitialized = true;
        _siteStatus = SiteStatus.PLACED;
    }

    bool IHakoniwaObject.IsInitialized()
    {
        return _isInitialized;
    }

    IBuilding ISite.GetBuilding()
    {
        return _building;
    }

    IConstructionSite ISite.GetConstructionSite()
    {
        return _constructionSite;
    }
    SiteStatus ISite.GetSiteStatus()
    {
        return _siteStatus;
    }

    void ISite.SetOnConstructionCompletedAction(Action action)
    {
        if (_constructionSite == null)
        {
            Debug.LogWarning("_constructionSite is null");
        }
        else
        {
            _constructionSite.SetOnConstructionCompletedAction(action);
        }
    }

    IJob IJobView.GetJob()
    {
        return _constructionSite.GetJob();
    }

    void IWorker.Assign(AssignedJob item)
    {
        throw new NotImplementedException();
    }

    void IWorker.DoWork()
    {
        throw new NotImplementedException();
    }

    List<IAbility> IWorker.GetAbilities()
    {
        throw new NotImplementedException();
    }

    AssignedJob IWorker.GetAssignedJob()
    {
        throw new NotImplementedException();
    }

    bool IWorker.IsAssigned()
    {
        throw new NotImplementedException();
    }
}
