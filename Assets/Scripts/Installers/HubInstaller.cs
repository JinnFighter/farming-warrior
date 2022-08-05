using System;
using UnityEngine;
using Zenject;

namespace FarmingWarrior
{
    public class HubInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            BindInputActions();
            BindSceneData();
        }

        private void BindSceneData()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        }

        private void BindInputActions()
        {
            Container.Bind<InputActions>().AsSingle();
        }
    }
}
