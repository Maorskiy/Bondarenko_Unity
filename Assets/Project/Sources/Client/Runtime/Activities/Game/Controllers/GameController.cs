using System;
using Client.Runtime.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            Assert.IsNotNull(_playerPresenter);
        }

        private void Start()
        {
            _playerPresenter.Enable();
        }

        private void OnDestroy()
        {
            _playerPresenter.Disable();
        }
    }
}