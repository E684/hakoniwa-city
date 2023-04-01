using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity;
using HakoniwaCity.Building;

public class ResourceSelectButton : MonoBehaviour
{
    public GameObject obj;
    public MapPointer pointer;

    public void OnSelected()
    {
        pointer.SetConstructionCandidate(obj);
    }
}
