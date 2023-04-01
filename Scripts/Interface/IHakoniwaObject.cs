using System;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    public interface IHakoniwaObject
    {
        public void InitializeObject();
        public bool IsInitialized();

        public void Action();
    }

    public struct HakoniwaObjectHealth
    {
        public float value;
    }
}

