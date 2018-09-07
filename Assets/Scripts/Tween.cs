using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Move() {
		var ts = this.transform;
		ts.DOMove (
			Vector3.one,
			1.0f
		).SetRelative ()
		.OnStart(() => {
			// アニメーションが終了時によばれる
			Debug.Log("Start!");
		})
		.OnComplete(() => {
			// アニメーションが終了時によばれる
			Debug.Log("Complete!");
		});
	}

//	public void ToAlpha() {
//		var color = this.renderer.material.color
//		// Alphaだけを変えたい場合はこちらも
//		DOTween.ToAlpha(
//			() => image.color,
//			color => image.color = color,
//			0f,                                // 最終的なalpha値
//			3f
//		);
//	}
}
