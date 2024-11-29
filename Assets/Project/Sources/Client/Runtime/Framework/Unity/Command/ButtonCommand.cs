using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Client.Runtime.Framework
{
    public abstract class ButtonCommand : MonoCommand
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            Assert.IsNotNull(_button, $"[ButtonCommand] Button is required");

            _button.onClick.AddListener(Execute);
        }

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveListener(Execute);
        }
    }
}