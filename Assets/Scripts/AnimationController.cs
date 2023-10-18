using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Start()
    {
        animator.enabled = false;
    }

    public void ChangeAnimationState()
    {
        animator.enabled = true;
        animator.Play("Walking");
    }

    public void StopAnimationState()
    {
        animator.enabled = false;
    }
}
