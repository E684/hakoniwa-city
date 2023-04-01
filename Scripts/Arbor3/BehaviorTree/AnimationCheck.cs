using UnityEngine;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class AnimationCheck : Decorator {
	public Animator animator;
	public string animationName;
	private bool _isPlaying;

	protected override void OnAwake() {
	}

	protected override void OnStart() {
	}

	protected override bool OnConditionCheck() {
        if (_isPlaying)
        {
			return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
		}

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName)){
			_isPlaying = true;
		}
		return true;
	}

	protected override void OnEnd() {
	}
}
