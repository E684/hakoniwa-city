using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private bool _isEnabled = false;
    private Collider collider;
    public void Start()
    {
        collider = GetComponent<Collider>();
    }

    public void SetEnabled(bool value)
    {
        //_isEnabled = value;
        collider.enabled = value;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (!_isEnabled) return;

        Debug.Log("OnCollisionStay");
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if(damagable != null)
        {
            damagable.OnDamage();
        }
    }
}
