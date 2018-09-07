using UnityEngine;
using UniRx;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private bool IsStunned
    {
        set { animator.SetBool("IsStunned", value); }
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        var playerStatus = GetComponent<PlayerStatus>();

        //気絶フラグが書き換わったらAnimatorの気絶フラグに反映
        playerStatus.IsStunned.Subscribe(x => IsStunned = x);
        Debug.Log("IsStunned is changed: " + "s");
    }
}