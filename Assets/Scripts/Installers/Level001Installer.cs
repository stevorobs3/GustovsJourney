using OnsightGames.Gustov.GameObjects;
using UnityEngine;

namespace OnsightGames.Gustov.Installer
{
    public class Level001Installer : BaseInstaller
    {
        public override void InstallBindings()
        {
            InstallGameObject<PixelPerfectCamera>("Prefabs/PixelPerfectCamera");
            InstallGameObject<PlatformGameObject>("Prefabs/Platform");
            InstallGameObject<BackgroundHillsGameObject>("Prefabs/BackgroundHills");
            InstallGameObject<BackgroundTreesGameObject>("Prefabs/BackgroundTrees");
            InstallGameObject<GustovGameObject>("Prefabs/Gustov");
            InstallGameObject<GroundGameObject>("Prefabs/Ground");
        }
    }
}