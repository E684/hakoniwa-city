using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class ActionCheckDecorator : Decorator {

	public string checkString;
	public string targetString;
	protected override void OnAwake() {
	}

	protected override void OnStart() {
	}

	protected override bool OnConditionCheck() {
		return checkString == targetString;
	}

	protected override void OnEnd() {
	}
}
