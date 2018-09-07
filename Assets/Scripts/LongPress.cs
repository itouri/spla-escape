using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class LongPress : MonoBehaviour
{
	private GameObject _tween;

	void Start()
	{
		_tween  = GameObject.Find("Tween");

		var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
		var mouseUpStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonUp(0));

		//長押しの判定
		//マウスクリックされたら3秒後にOnNextを流す
		mouseDownStream
			.SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(2)))
			//途中でMouseUpされたらストリームをリセット
			.TakeUntil(mouseUpStream)
			.RepeatUntilDestroy(this.gameObject)
			.Subscribe(_ => CallMove());

		//長押しのキャンセル判定
		mouseDownStream.Timestamp()
			.Zip(mouseUpStream.Timestamp(), (d, u) => (u.Timestamp - d.Timestamp).TotalMilliseconds / 1000.0f)
			.Where(time => time < 2.0f)
			.Subscribe(t => Debug.Log(t + "秒でキャンセル"));
	}

	private void CallMove() {
		_tween.GetComponent<Tween> ().Move ();
	}
}
