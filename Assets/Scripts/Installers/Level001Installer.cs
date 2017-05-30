using OnsightGames.Gustav.Controllers;
using OnsightGames.Gustav.GameObjects;
using OnsightGames.Gustav.Services;
using OnsightGames.Gustav.ViewControllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OnsightGames.Gustav.Installers
{
    public class Level001Installer : BaseInstaller
    {
        public override void InstallBindings()
        {
            InstallGameObject<PixelPerfectCamera>("Prefabs/PixelPerfectCamera");
            InstallGameObject<PlatformGameObject>("Prefabs/Platform");
            InstallGameObject<BackgroundHillsGameObject>("Prefabs/BackgroundHills");
            InstallGameObject<BackgroundTreesGameObject>("Prefabs/BackgroundTrees");
            InstallGameObject<GustavGameObject>("Prefabs/Gustav");
            InstallGameObject<GroundGameObject>("Prefabs/Ground");

            CreateGameObject<GustavInput>();
            BindAllAsSingle<GustavController>();

            CreateGameObject<Canvas>();
            CreateGameObject<EventSystem>();
            BindAllAsSingle<CanvasController>();

            InstallUI();
            InstallLevelController();
            InstallTeacups();
        }


        private void InstallTeacups()
        {
            BindAllAsSingle<TeacupsController>();
            Container.BindMemoryPool<TeacupGameObject, TeacupGameObject.Pool>()
            .WithInitialSize(5)
            .FromComponentInNewPrefabResource("Prefabs/Teacup")
            .UnderTransformGroup("Teacups");
        }
        private void InstallLevelController()
        {
            BindAllAsSingle<LevelController>();
        }

        private void InstallUI()
        {
            BindAllAsSingle<ScoreController>();
            InstallGameObject<ScoreDisplay>("Prefabs/ScoreDisplay");
        }
    }
}