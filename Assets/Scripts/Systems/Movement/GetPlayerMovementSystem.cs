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
            var isPressed = _playerActions.Move.WasPressedThisFrame();
            var isReleased = _playerActions.Move.WasReleasedThisFrame();

            if(isPressed || isReleased)
            {
                foreach(var index in _filter)
                {
                    var entity = _filter.GetEntity(index);
                    if(isPressed)
                    {
                        if(!entity.Has<MoveEvent>())
                        {
                            ref var moveEvent = ref entity.Get<MoveEvent>();
                            moveEvent.Direction = _playerActions.Move.ReadValue<Vector2>();
                        }
                    }
                    else if(isReleased)
                    {
                        if (entity.Has<MoveEvent>())
                        {
                            entity.Del<MoveEvent>();
                        }
                    }
                }
            }
        }
    }
}
