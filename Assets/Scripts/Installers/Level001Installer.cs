using OnsightGames.Gustov.Controllers;
using OnsightGames.Gustov.GameObjects;
using OnsightGames.Gustov.ViewControllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OnsightGames.Gustov.Installers
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

            CreateGameObject<GustovInput>();
            BindAllAsSingle<GustovController>();

            CreateGameObject<Canvas>();
            CreateGameObject<EventSystem>();
            BindAllAsSingle<CanvasController>();

            InstallGameObject<GustovStats>("Prefabs/GustovStats");

        }
    }
}