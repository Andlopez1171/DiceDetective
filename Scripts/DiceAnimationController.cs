using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAnimationController : MonoBehaviour
{
    public Animator animator;

    public void ChangeAnimationState(string name)
    {
        animator.enabled = true;
        animator.Play(name);
    }
}
