using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using HakoniwaCity;
using HakoniwaCity.Character;
using HakoniwaCity.Ability;
using HakoniwaCity.Job;

[RequireComponent(typeof(NavMeshAgent))]
public class HM_Citizen : MonoBehaviour, IHakoniwaObject, ICitizenView, IDamagable
{
    private ICitizen _citizen;
    private ICharacter _character;
    private IWorker _worker;
    private bool _isInitialized = false;

    private Vector3 _destination;
    private bool _hasNextDestination;

    void Update()
    {
        if (!_isInitialized) return;

        Action();
    }

    private bool HasAssignedJob()
    {
        bool ret = _worker.IsAssigned();
        return ret;
    }

    private void UpdateNextDestination()
    {
        if (HasAssignedJob())
        {
            AssignedJob job = _worker.GetAssignedJob();
            _destination = job.GetJobLocation();
            _hasNextDestination = true;
        }
        else
        {
            _hasNextDestination = false;
        }
    }

    /// ////////// IHakoniwaObject
    public void InitializeObject()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        List<IAbility> abilities = new List<IAbility>();
        AbilityValue abilityValue = new AbilityValue(initialValue: 0.1f);
        abilities.Add(new ConstructionAbility(abilityValue));
        _citizen = new Citizen(transform: transform, agent: agent, initialAbilities: abilities);

        _character = _citizen.GetCharacter();
        _worker = _citizen.GetWorker();
        _hasNextDestination = false;

        _isInitialized = true;
    }

    public void Action()
    {
        UpdateNextDestination();
        if(_hasNextDestination)
        {
            _character.Move(_destination);
        }

        _worker.DoWork();
    }

    public bool IsInitialized()
    {
        return _isInitialized;
    }

    /// ////////// ICitizenView
    public ICitizen GetCitizen()
    {
        return _citizen;
    }

    /// ////////// IDamagable
    public void OnDamage()
    {
        Debug.Log($"{gameObject.name} OnDamage");
    }
}
