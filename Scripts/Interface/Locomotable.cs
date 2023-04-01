using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Locomotable
{
    public void SetWaypoints(Transform[] waypoints);
    public void StartLocomote();

}
