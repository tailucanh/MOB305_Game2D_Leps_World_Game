using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimator : MonoBehaviour
{
    public float repeatInterval = 2.5f; // repeat interval in seconds

    private Animator animator;
  

    void Start()
    {
        animator = GetComponent<Animator>();
     
        InvokeRepeating("PlayAnimation", repeatInterval, repeatInterval); // repeat the animation every 'repeatInterval' seconds
    }

    void PlayAnimation()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(currentState.fullPathHash, -1, 0);
     
    }
}
