using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;

    public void Init(MovementBase _walk)
    {
        _anim = GetComponent<Animator>();

        if (_walk != null)
            _walk.OnWalk += HandleWalk;
        if (_walk != null)
            _walk.OnIdle += HandleIdle;
        if (_walk != null)
            _walk.OnJump += HandleJump;
        if (_walk != null)
            _walk.OnDeath += HandleDeath;
    }


    private void HandleWalk()
    {
        GoToWalk();
    }
    private void HandleJump()
    {
        GoToJump();
    }
    private void HandleDeath()
    {
        GoToDeath();
    }
    private void HandleIdle()
    {
        GoToIdle();
    }

    private void GoToWalk()
    {
        _anim.ResetTrigger("GoToIdle");
        _anim.SetTrigger("GoToWalk");
    }
    private void GoToJump()
    {
        _anim.ResetTrigger("GoToWalk");
        _anim.ResetTrigger("GoToIdle");
        _anim.SetTrigger("GoToJump");
    }
    private void GoToDeath()
    {
        _anim.SetTrigger("GoToDeath");
    }
    private void GoToIdle()
    {
        _anim.ResetTrigger("GoToWalk");
        _anim.SetTrigger("GoToIdle");
    }

}
