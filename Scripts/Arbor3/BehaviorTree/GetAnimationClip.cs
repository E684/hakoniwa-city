using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.Animations;

[AddComponentMenu("")]
public class GetAnimationClip : Calculator {
	[SerializeField]
	private FlexibleGameObject gameobject = new FlexibleGameObject();

	[SerializeField]
	private OutputSlotAnimationClip _Output = new OutputSlotAnimationClip();
	// Use this for calculate
	public override void OnCalculate() {
		Animator animator = gameobject.value.GetComponent<Animator>();
		if (animator == null) return;

		AnimatorClipInfo info = animator.GetCurrentAnimatorClipInfo(0)[0];
		_Output.SetValue(info.clip);

	}
}
