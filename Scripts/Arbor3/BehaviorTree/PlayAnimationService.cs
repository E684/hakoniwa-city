using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class PlayAnimationService : Service {
	[SerializeField]
	private FlexibleGameObject gameobject = new FlexibleGameObject();

	private AnimationController animationController;
	public AnimationController.AnimationKind kind;

	protected override void OnAwake() {
		animationController = gameobject.value.GetComponent<AnimationController>();
	}

	protected override void OnStart() {
		if(animationController != null)
        {
			animationController.SetAnimation(kind);
		}
	}

	protected override void OnUpdate() {
	}

	protected override void OnEnd() {
	}
}
