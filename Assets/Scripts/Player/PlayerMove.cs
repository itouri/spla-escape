using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(PlayerStatus))]

public class PlayerMove : MonoBehaviour
{
    private bool _canMove;

    // Use this for initialization
    void Start()
    {
        var playerStatus = GetComponent<PlayerStatus>();
        playerStatus.IsStunned.Subscribe(x => Debug.Log("_canMove is changed: " + x));
    }
}
