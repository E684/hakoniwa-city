using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Ability
    {
        /// <summary>
        /// 他オブジェクトに作用する能力の振る舞いを定義するインタフェース
        /// </summary>
        public interface IAbility
        {
            public AbilityKind GetKind();

            public AbilityValue GetValue();
            public AbilityRank GetRank();
            public string ToString();
        }

        public enum AbilityKind
        {
            LOCOMOTION,
            CONSTRUCTION,
            OBJECT_SPAWN
        }

        public struct AbilityValue
        {
            public AbilityValue(float initialValue)
            {
                value = initialValue;
            }
            public float value;
        }

        public struct AbilityRank
        {
            public float value;
        }
    }
}
