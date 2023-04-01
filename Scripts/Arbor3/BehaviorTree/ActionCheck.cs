using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class ActionCheck : Decorator {

	public FlexibleString action = new FlexibleString();
	private ParameterContainer _parameter = new ParameterContainer();

	public string targetAction;

	protected override void OnAwake() {
		_parameter = gameObject.GetComponent<ParameterContainer>();
	}

	protected override void OnStart() {
	}

	protected override bool OnConditionCheck() {
		string action = _parameter.GetString("Action");

		return action == targetAction;
	}

	protected override void OnEnd() {
	}
}
