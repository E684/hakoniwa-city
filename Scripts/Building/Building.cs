using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Building;

public class Building : IBuilding
{
    private GameObject _buildingPrefab;
    private MeshRenderer _prefabMeshRenderer;
    private Vector3 _position;
    private Quaternion _rotation;

    public Building(GameObject buildingPrefab)
    {
        _buildingPrefab = buildingPrefab;
        _prefabMeshRenderer = buildingPrefab.GetComponentInChildren<MeshRenderer>();
        _position = Vector3.zero;
    }

    ///////////////////////IBuilding
    public GameObject GetBuildingPrefab()
    {
        return _buildingPrefab;
    }

    public MeshRenderer GetBuildingView()
    {
        return _prefabMeshRenderer;
    }

    public Vector3 GetPosition()
    {
        return _position;
    }

    public void SetPosition(Vector3 position)
    {
        _position = position; ;
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }

    public void SetRotation(Quaternion rotation)
    {
        _rotation = rotation;
    }
}
