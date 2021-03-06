﻿using OnsightGames.Gustav.Controllers;
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

            InstallTeabags();
            InstallUI();
            InstallIsavelle();
            InstallLevelTimer();
            InstallLevelController();

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