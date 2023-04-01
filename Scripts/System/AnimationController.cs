using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public enum AnimationKind
    {
        IDLE,
        WALK = 6,
        PUT_TENT = 10
    }

    public void SetAnimation(AnimationKind value)
    {
        animator.SetInteger("animation", (int)value);
    }

}
