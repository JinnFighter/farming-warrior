using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmingWarrior
{
    public class MovePlayerCameraSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerView, MoveEvent, PlayerCamera> _filter = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var moveEvent = _filter.Get2(index);
                var playerCamera = _filter.Get3(index);
                playerCamera.Camera.transform.position += moveEvent.Direction * Time.deltaTime;
            }
        }
    }
}
