using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmingWarrior
{
    public class InitPlayerCameraSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Player> _filter = null;
        private readonly Camera _camera = null;

        public void Init()
        {
            foreach(var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                ref var playerCamera = ref entity.Get<PlayerCamera>();
                playerCamera.Camera = _camera;
            }
        }
    }
}
