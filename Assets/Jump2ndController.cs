using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2ndController : MonoBehaviour
{
    public int jumpCount = 0;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount == 2)
        {
            _animator.SetBool("jump_2nd",true);
        }
        if (jumpCount != 2)
        {
            _animator.SetBool("jump_2nd",false);
        }

    }
}
