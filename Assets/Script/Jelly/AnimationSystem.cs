using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    public RuntimeAnimatorController[] controllers;

    private Animator animator;

    private readonly int walkHash = Animator.StringToHash("isWalk");
    private readonly int touchHash = Animator.StringToHash("doTouch");
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = controllers[0];
    }
    private void Start()
    {
        GetComponent<JellyController>().OnMoveEvent += MoveAnimation;
        GetComponent<JellyController>().OnTouchEvent += TouchAnimation;
    }
    public void SetAnimationController(int level)
    {
        if (level > 2)
            level = 2;

        animator.runtimeAnimatorController = controllers[level];
    }

    private void MoveAnimation(Vector2 obj)
    {
        animator.SetBool(walkHash, obj != Vector2.zero);
    }

    private void TouchAnimation()
    {
        animator.SetTrigger(touchHash);
    }
}
