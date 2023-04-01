using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Building;
using HakoniwaCity.Character;
using HakoniwaCity.Log;
using HakoniwaCity.Job;

public class MapPointer : MonoBehaviour
{
    public HakoniwaCityInputs inputs;
    public Camera camera;


    private HM_Citizen _debugCitizen;
    private HM_HouseGameLogic _houseGameLogic;
    private bool _hasConstructionCandidate = false;
    public GameObject DebugWorker;


    private void Start()
    {
        _debugCitizen = DebugWorker.GetComponent<HM_Citizen>();
        _debugCitizen.InitializeObject();
    }

    public void SetConstructionCandidate(GameObject obj)
    {
        _houseGameLogic = new HM_HouseGameLogic();
        _hasConstructionCandidate = _houseGameLogic.Initialize(obj);
        HakoniwaLogger.Log($"HM_HouseOperator initialize {_hasConstructionCandidate}");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasConstructionCandidate) return;

        OnMoveCursor();
        OnClick();
    }

    private void OnMoveCursor()
    {
        if (_houseGameLogic == null) return;

        _houseGameLogic.ShowConstructionSiteCandidate(camera, inputs.GetCursorPoint());
    }
    private void OnClick()
    {
        Vector2 touchPoint = Vector2.zero;
        if (!inputs.GetTouchPoint(ref touchPoint)) return;

        if (_houseGameLogic == null) return;

        bool put_success = _houseGameLogic.PutConstructionSite(camera, touchPoint);
        if (put_success)
        {
            _houseGameLogic.AssignJob(_debugCitizen.GetCitizen().GetWorker());
            _houseGameLogic = null;
            _hasConstructionCandidate = false;
        }
    }
}
