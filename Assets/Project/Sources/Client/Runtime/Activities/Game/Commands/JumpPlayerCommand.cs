//using Client.Runtime.Framework;
//using UnityEngine;
//using UnityEngine.Assertions;
//using Zenject;

//namespace Client.Runtime
//{
//    public sealed class JumpPlayerCommand : KeyDownCommand
//    {
        
//        [SerializeField] private PlayerView _playerView;

//        [Inject] private readonly PlayerModel _playerModel;
        
//        protected override void Awake()
//        {
//            base.Awake();
//            Assert.IsNotNull(_playerView);
//        }

//        public override void Execute()
//        {
//            if (_playerModel.IsGrounded)
//            {
//                _playerView.RigidBody.AddForce(_playerView.transform.up * 700, ForceMode2D.Impulse);
//                _playerModel.IsGrounded = false;
//            }
//        }
//    }
//}