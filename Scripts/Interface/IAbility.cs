using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Ability
    {
        /// <summary>
        /// ���I�u�W�F�N�g�ɍ�p����\�͂̐U�镑�����`����C���^�t�F�[�X
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
