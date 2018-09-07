using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Mvp
{
    public class Presenter : MonoBehaviour
    {
        // Model
        private Model _model;

        // View
        [SerializeField]
        private InputField scoreInputField;

        void Start()
        {
            scoreInputField.text = "0";

           _model = GameObject.Find("Model").GetComponent<Model>();

            scoreInputField
                .OnValueChangedAsObservable()
                .Subscribe(x => _model.Score.Value = int.Parse(x));

            _model.Score
                .Subscribe(x => scoreInputField.text = ""+x);
        }
    }
}
