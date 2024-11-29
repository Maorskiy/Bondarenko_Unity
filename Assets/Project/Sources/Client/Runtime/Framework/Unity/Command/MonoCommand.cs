using UnityEngine;

namespace Client.Runtime.Framework
{
    public abstract class MonoCommand : MonoBehaviour, ICommand
    {
        public abstract void Execute();
    }
}