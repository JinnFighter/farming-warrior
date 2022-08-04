using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace FarmingWarrior
{
    sealed class HubStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;

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

        }

        private void AddInjections()
        {

        }

        private void AddOneFrameComponents()
        {
            _systems
                .OneFrame<MoveEvent>();
        }
    }
}