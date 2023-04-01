using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HakoniwaCity.Ability;

public class LocomotionAbility : IAbility
{
    private AbilityKind _kind = AbilityKind.LOCOMOTION;
    private AbilityRank _rank;
    private AbilityValue _value;

    public LocomotionAbility()
    {
        _rank.value = 0f;
        _value.value = 0f;
    }

    public AbilityKind GetKind()
    {
        return _kind;
    }

    public AbilityValue GetValue()
    {
        return _value;
    }

    public AbilityRank GetRank()
    {
        return _rank;
    }
    public string ToString()
    {
        return "LocomotionAbility";
    }
}
