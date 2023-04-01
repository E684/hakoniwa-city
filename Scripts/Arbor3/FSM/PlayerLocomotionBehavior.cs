using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class PlayerLocomotionBehavior : StateBehaviour {
	[SerializeField]
	private FlexibleVector3 speed = new FlexibleVector3();  
	
	
	// Use this for initialization
	void Start () {
	
	}

	// Use this for awake state
	public override void OnStateAwake() {
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() {
		transform.LookAt(transform.position + speed.value);
		transform.Translate(speed.value * Time.deltaTime, Space.World);
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
