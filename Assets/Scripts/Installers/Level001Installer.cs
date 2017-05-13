using Zenject;

public class Level001Installer : MonoInstaller {

    public override void InstallBindings()
    {
        Container.Bind<PixelPerfectCamera>()
            .FromComponentInNewPrefabResource("Prefabs/PixelPerfectCamera")
            .AsSingle()
            .NonLazy();
    }
}