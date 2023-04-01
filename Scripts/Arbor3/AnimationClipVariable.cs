using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[System.Serializable]
public class FlexibleAnimationClip : FlexibleField<AnimationClip>
{
	public FlexibleAnimationClip(AnimationClip value) : base(value)
	{
	}

	public FlexibleAnimationClip(AnyParameterReference parameter) : base(parameter)
	{
	}

	public FlexibleAnimationClip(InputSlotAny slot) : base(slot)
	{
	}

	public static explicit operator AnimationClip(FlexibleAnimationClip flexible)
	{
		return flexible.value;
	}

	public static explicit operator FlexibleAnimationClip(AnimationClip value)
	{
		return new FlexibleAnimationClip(value);
	}
}

[System.Serializable]
public class InputSlotAnimationClip : InputSlot<AnimationClip>
{
}

[System.Serializable]
public class OutputSlotAnimationClip : OutputSlot<AnimationClip>
{
}

[AddComponentMenu("")]
public class AnimationClipVariable : Variable<AnimationClip>
{
}