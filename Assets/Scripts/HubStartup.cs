using Leopotam.Ecs;
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

        void Start() 
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            AddExtensions();
            AddSystems();
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

        private void AddSystems()
        {
            _systems
                .Add(new GetPlayerMovementSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_inputActions.Player);
        }

        private void AddOneFrameComponents()
        {
            _systems
                .OneFrame<MoveEvent>();
        }
    }
}