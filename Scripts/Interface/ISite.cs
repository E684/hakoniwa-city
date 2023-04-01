using System;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Building
    {
        /// <summary>
        /// 特定の目的のために使用されている土地の振る舞いを定義するインタフェース
        /// </summary>
        public interface ISite
        {
            public IConstructionSite GetConstructionSite();
            public void SetOnConstructionCompletedAction(Action action);

            public IBuilding GetBuilding();

            public SiteStatus GetSiteStatus();
        }

        public enum SiteStatus
        {
            PLACED,
            UNDER_CONSTRUCTION,
            BUILT,
            DISSOLUTION,
        }
    }
}
