using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Framework
{
    public abstract class KeyDownCommand : MonoCommand
    {
        [SerializeField] private KeyCode _key;

        protected virtual void Awake()
        {
            Assert.AreNotEqual(KeyCode.None, _key, "[KeyDownCommand] Define the key code");
        }

        private void Update()
        {
            if (Input.GetKeyUp(_key))
            {
                Execute();
            }
        }
    }
}