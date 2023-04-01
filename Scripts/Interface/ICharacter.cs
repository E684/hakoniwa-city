using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Character
    {
        public interface ICharacter
        {
            public void Move(Vector3 destination);
            public void Communicate();
        }

        public interface ICharacterView
        {
            public ICharacter GetCharacter();
        }
    }
}
