using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HakoniwaCity.Ability;

public class ConstructionAbility : IAbility
{
    private AbilityKind _kind = AbilityKind.CONSTRUCTION;
    private AbilityRank _rank;
    private AbilityValue _value;

    public ConstructionAbility()
    {
        _rank.value = 0f;
        _value.value = 0f;
    }

    public ConstructionAbility(AbilityValue initialAbilityValue)
    {
        _rank.value = 0f;
        _value = initialAbilityValue;
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
        return "ConstructionAbility";
    }
}
