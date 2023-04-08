using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HakoniwaCity.Ability;

public class ObjectSpawnAbility : IAbility
{
    private AbilityKind _kind = AbilityKind.OBJECT_SPAWN;
    private AbilityRank _rank;
    private AbilityValue _value;

    public ObjectSpawnAbility(AbilityValue initialAbilityValue)
    {
        _rank.value = 0f;
        _value = initialAbilityValue;
    }

    public ObjectSpawnAbility()
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
        return "ObjectSpawnAbility";
    }
}
