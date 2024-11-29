using System;
using Client.Runtime.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public sealed class StartGameCommand : ButtonCommand
    {
        private AsyncOperation _operation;
        
        public override void Execute()
        {
            if (_operation != default)
            {
                return;
            }
            
            _operation = SceneManager.LoadSceneAsync(Scenes.Activities.Game, LoadSceneMode.Additive);
            _operation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            Scene gameScene = SceneManager.GetSceneByName(Scenes.Activities.Game);
            if (gameScene != default)
            {
                SceneManager.SetActiveScene(gameScene);
            }

            Complete();
        }

        private void Complete()
        {
            if (_operation != default)
            {
                _operation.completed -= ActivateScene;
            }
            _operation = default;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Complete();
        }
    }
}