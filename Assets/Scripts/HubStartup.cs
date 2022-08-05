using Leopotam.Ecs;
using System;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace FarmingWarrior
{
    sealed class HubStartup : MonoBehaviour 
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject]
        private InputActions _inputActions;

        [Inject]
        private Camera _playerCamera;

        void Start() 
        {
            _inputActions.Enable();
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            AddExtensions();
            AddInitSystems();
            AddRunSystems();
            AddOneFrameComponents();
            AddInjections();

            _systems.Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy() 
        {
            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }

        private void AddExtensions()
        {
            _systems
                .ConvertScene();
        }

        private void AddInitSystems()
        {
            _systems
                .Add(new InitPlayerCameraSystem());
        }

        private void AddRunSystems()
        {
            _systems
                .Add(new GetPlayerMovementSystem())
                .Add(new MoveMovableSystem())
                .Add(new MovePlayerCameraSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_inputActions.Player)
                .Inject(_playerCamera);
        }

        private void AddOneFrameComponents()
        {
        }
    }
}