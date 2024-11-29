using UnityEngine;

namespace Client.Runtime.Framework
{
    public abstract class MonoPresenter : MonoBehaviour, IPresenter
    {
        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }
    }
}