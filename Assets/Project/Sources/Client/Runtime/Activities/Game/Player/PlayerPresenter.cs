using System;
using Client.Runtime.Framework;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Client.Runtime
{
    public sealed class PlayerPresenter : MonoPresenter
    {
        [SerializeField] private PlayerView _playerView;

        [Inject] private readonly PlayerModel _playerModel;
        
        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[PlayerPresenter] PlayerView is required");
        }

        public override void Enable()
        {
            _playerView.OnPlayerGrounded += PlayerGrounded;
        }

        private void PlayerGrounded()
        {
            _playerModel.IsGrounded = true;
        }

        public override void Disable()
        {
            _playerView.OnPlayerGrounded -= PlayerGrounded;
        }
    }
}