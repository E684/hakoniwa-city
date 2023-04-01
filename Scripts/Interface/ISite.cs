using System;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Building
    {
        /// <summary>
        /// ����̖ړI�̂��߂Ɏg�p����Ă���y�n�̐U�镑�����`����C���^�t�F�[�X
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
