using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    public delegate void WalkEvent();
    public WalkEvent OnWalk;
    public delegate void JumpEvent();
    public JumpEvent OnJump;
    public delegate void DeathEvent();
    public DeathEvent OnDeath;
    public delegate void IdleEvent();
    public DeathEvent OnIdle;
}
