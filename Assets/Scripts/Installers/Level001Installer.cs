using OnsightGames.Gustov.GameObject;
using Zenject;
namespace OnsightGames.Gustov.Installer
{
    public class Level001Installer : BaseInstaller
    {
        public override void InstallBindings()
        {
            InstallGameObject<PixelPerfectCamera>("Prefabs/PixelPerfectCamera");
            InstallGameObject<PlatformGameObject>("Prefabs/Platform");
            InstallGameObject<GustovGameObject>("Prefabs/Gustov");
        }
    }
}