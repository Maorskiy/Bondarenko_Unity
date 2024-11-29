using System;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class PlayerModel
    {
        private bool _isAlive;
        public event Action PlayerIsAliveChanged;
        
        public bool IsGrounded { get; set; }

        public bool IsAlive
        {
            get => _isAlive;
            set
            {
                _isAlive = value;
                PlayerIsAliveChanged?.Invoke();
            }
        }
    }
}