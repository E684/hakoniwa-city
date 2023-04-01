using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class PlayerInputService : Service {
	private ParameterContainer _parameter;
	[SerializeField] private OutputSlotVector3 _Result = new OutputSlotVector3();

	protected override void OnAwake() {
		_parameter = gameObject.GetComponent<ParameterContainer>();
	}

	protected override void OnStart() {
	}

	protected override void OnUpdate() {
		Vector3 speed = _parameter.GetVector3("Speed");

		_Result.SetValue(speed);
	}

	protected override void OnEnd() {
	}
}
