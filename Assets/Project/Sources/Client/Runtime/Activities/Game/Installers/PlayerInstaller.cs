using Zenject;

namespace Client.Runtime
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerModel>()
                .AsSingle();
        }
    }
}