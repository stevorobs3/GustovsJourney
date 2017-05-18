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
            InstallCamera();
            InstallPlatforms();
            InstallGustav();
            InstallBackground();
            InstallCanvas();
            InstallTeabags();
            InstallUI();
            InstallIsavelle();
            InstallLevelTimer();
            InstallLevelController();
        }

        private void InstallCanvas()
        {
            CreateGameObject<Canvas>();
            CreateGameObject<EventSystem>();
            BindAllAsSingle<CanvasController>();
        }

        private void InstallCamera()
        {
            BindAllAsSingle<CameraController>();
            InstallGameObject<PixelPerfectCamera>("Prefabs/PixelPerfectCamera");
        }

        private void InstallBackground()
        {
            InstallGameObject<BackgroundHillsGameObject>("Prefabs/BackgroundHills");
            InstallGameObject<BackgroundTreesGameObject>("Prefabs/BackgroundTrees");
        }

        private void InstallGustav()
        {
            
            InstallGameObject<GustavGameObject>("Prefabs/Gustav");
            CreateGameObject<GustavInput>();
            BindAllAsSingle<GustavController>();

        }

        private void InstallPlatforms()
        {
            BindAllAsSingle<PlatformController>();
            InstallGameObject<PlatformGameObject>("Prefabs/Platform");
            InstallGameObject<PlatformGameObject>("Prefabs/Ground");
        }

        private void InstallLevelController()
        {
            BindAllAsSingle<LevelController>();
        }

        private void InstallLevelTimer()
        {
            InstallGameObject<LevelTimerGameObject>("Prefabs/LevelTimer");
            BindAllAsSingle<LevelTimerController>();
        }

        private void InstallIsavelle()
        {
            InstallGameObject<IsabelleGameObject>("Prefabs/Isabelle");
            BindAllAsSingle<IsabelleController>();
        }

        private void InstallTeabags()
        {
            InstallGameObject<TeabagGameObject>("Prefabs/Teabag");
            BindAllAsSingle<TeabagController>();
        }

        private void InstallUI()
        {
            BindAllAsSingle<ScoreController>();
            InstallGameObject<ScoreDisplay>("Prefabs/ScoreDisplay");
        }
    }
}