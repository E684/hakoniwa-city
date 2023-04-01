using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HakoniwaCity
{
    namespace Character
    {
        public interface ICitizen
        {
            public ICharacter GetCharacter();

            public IWorker GetWorker();
        }

        public interface ICitizenView{
            public ICitizen GetCitizen();
        }
    }
}
