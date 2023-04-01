using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class LocomotionBehavior : ActionBehaviour {
	private ParameterContainer _parameter;

	protected override void OnAwake() {
		_parameter = gameObject.GetComponent<ParameterContainer>();
	}

	protected override void OnStart() {
	}

	protected override void OnExecute() {
		Vector3 speed = _parameter.GetVector3("Speed");

		transform.LookAt(transform.position + speed);
		transform.Translate(speed * Time.deltaTime, Space.World);
	}

	protected override void OnEnd() {
	}
}
