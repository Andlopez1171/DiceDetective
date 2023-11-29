using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Sprite defaultState;
    SpriteRenderer player;

    public void Start()
    {
        player = GetComponent<SpriteRenderer>();
        animator.enabled = false;
    }

    public void SetStateDefault()
    {
        player.sprite = defaultState;
    }

    public void ChangeAnimationState()
    {
        animator.enabled = true;
        animator.Play("Walking");
    }

    public void StopAnimationState()
    {
        animator.enabled = false;
        SetStateDefault();
    }
}
