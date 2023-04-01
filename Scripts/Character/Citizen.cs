using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using HakoniwaCity;
using HakoniwaCity.Ability;
using HakoniwaCity.Character;
public class Citizen : ICitizen
{
    private ICharacter _character;
    private IWorker _worker;

    public Citizen(Transform transform, NavMeshAgent agent, List<IAbility> initialAbilities)
    {
        _character = new Humanoid(transform, agent);
        _worker = new WorkerOperator(transform, initialAbilities);
    }

    /////////////////////// ICitizen
    public ICharacter GetCharacter()
    {
        return _character;
    }

    public IWorker GetWorker()
    {
        return _worker;
    }
}
