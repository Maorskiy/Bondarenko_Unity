using Client.Runtime.Framework;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public sealed class PauseGameKeyCommand : KeyDownCommand
    {
        public override void Execute()
        {
            SceneManager.UnloadSceneAsync(Scenes.Activities.Game);
        }
    }
}