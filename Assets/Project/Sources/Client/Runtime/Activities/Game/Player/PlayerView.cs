using System;
using Client.Runtime.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D RigidBody => _rigidbody;
        
        public event Action OnPlayerGrounded;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                OnPlayerGrounded?.Invoke();   
            }
        }
    }
}