using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStatus : MonoBehaviour {
    [SerializeField]
    private float StunTime;

    /// <summary>
    /// 気絶フラグ
    /// </summary>
    public BoolReactiveProperty IsStunned = new BoolReactiveProperty();

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void ApplyDamage()
    {
        //既に気絶していないなら気絶させる
        if (!IsStunned.Value) StartCoroutine(StunCoroutine());
    }
    /// <summary>
    /// 気絶中に実行されるコルーチン
    /// </summary>
    private IEnumerator StunCoroutine()
    {
        //気絶フラグON
        IsStunned.Value = true;
        //適当に待機
        yield return new WaitForSeconds(StunTime);
        //気絶フラグOFF
        IsStunned.Value = false;
    }
}
