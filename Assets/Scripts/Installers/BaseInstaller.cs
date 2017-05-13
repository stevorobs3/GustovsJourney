using UnityEngine;
using Zenject;

namespace OnsightGames.Gustov.Installers
{
    public abstract class BaseInstaller : MonoInstaller
    {
        protected void InstallGameObject<Behaviour>(string resourceName) where Behaviour : MonoBehaviour
        {
            Container.Bind<Behaviour>()
                .To<Behaviour>()
                .FromComponentInNewPrefabResource(resourceName)
                .AsSingle()
                .NonLazy();
        }

        protected void CreateGameObject<Behaviour>() where Behaviour : MonoBehaviour
        {
            Container.Bind<Behaviour>()
                .To<Behaviour>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        protected void BindAllAsSingle<Controller>()
        {
            Container.BindInterfacesAndSelfTo<Controller>()
                .AsSingle()
                .NonLazy();
        }
    }
}