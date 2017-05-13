using UnityEngine;
using Zenject;

namespace OnsightGames.Gustov.Installer
{
    public abstract class BaseInstaller : MonoInstaller
    {
        protected void InstallGameObject<Behaviour>(string resourceName) where Behaviour : Component
        {
            Container.Bind<Behaviour>()
                .FromComponentInNewPrefabResource(resourceName)
                .AsSingle()
                .NonLazy();
        }
    }
}