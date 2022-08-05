using Leopotam.Ecs;
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
                var axisDirection = _playerActions.Move.ReadValue<Vector2>();
                var isMoving = axisDirection != Vector2.zero;
                var moveDirection = new Vector3(axisDirection.x, 0, axisDirection.y);
                foreach(var index in _filter)
                {
                    var entity = _filter.GetEntity(index);
                    if (isMoving)
                    {
                        ref var moveEvent = ref entity.Get<MoveEvent>();
                        moveEvent.Direction = moveDirection;
                    }
                    else
                    {
                        entity.Del<MoveEvent>();
                    }
                }
            }
        }
    }
}
