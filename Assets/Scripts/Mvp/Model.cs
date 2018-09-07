using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Mvp
{
    public class Model : MonoBehaviour
    {
        public ReactiveProperty<int> Score = new ReactiveProperty<int>();

        void Start ()
        {
            Score.Subscribe(x => Debug.Log(x));
        }
    }
}
