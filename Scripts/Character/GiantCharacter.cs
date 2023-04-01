using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCharacter : MonoBehaviour
{
    public AttackCollider attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAttackColliderEnabled(int value)
    {
        bool enabled = value != 0;
        attackCollider.SetEnabled(enabled);
        Debug.Log($"SetAttackColliderEnabled {enabled}");
    }
}
