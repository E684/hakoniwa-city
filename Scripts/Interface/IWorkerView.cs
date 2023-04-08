using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity{
    namespace Worker{
        public interface IWorkerView
        {
            IWorker GetWorker();
        }
    }
}
