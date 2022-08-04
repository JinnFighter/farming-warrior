using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputActions;

namespace FarmingWarrior
{
    public class GetPlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player> _filter = null;
        private readonly PlayerActions _playerActions;

        public void Run()
        {
            if(_playerActions.Move.WasPerformedThisFrame())
            {
                var moveDirection = _playerActions.Move.ReadValue<Vector2>();
                foreach(var index in _filter)
                {
                    var entity = _filter.GetEntity(index);
                    ref var moveEvent = ref entity.Get<MoveEvent>();
                    moveEvent.Direction = moveDirection;
                }
            }
        }
    }
}
