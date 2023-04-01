using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedKnightController : MonoBehaviour, IDamagable
{
    private NavMeshAgent _agent;
    private Transform _enemyTarget = null;
    private Vector3 _waitPosition;
    private float _health = 2;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _waitPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyTarget != null)
        {
            _agent.destination = _enemyTarget.position;
        }
        else
        {
            _agent.destination = _waitPosition;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            _enemyTarget = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (_enemyTarget == other.transform)
        {
            _enemyTarget = null;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if(damagable != null)
        {
            damagable.OnDamage();

            OnDamage();
        }
    }

    public void OnDamage()
    {
        _health = _health - 1f;
        if(_health < 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
