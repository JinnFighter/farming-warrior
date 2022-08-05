using Leopotam.Ecs;
using UnityEngine;

namespace FarmingWarrior
{
    public class MoveMovableSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Movable, MovableView, MoveEvent>.Exclude<MoveDisabled> _filter = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var movableView = _filter.Get2(index);
                var moveEvent = _filter.Get3(index);
                movableView.Rigidbody.MovePosition(movableView.Transform.position + moveEvent.Direction * Time.deltaTime);
            }
        }
    }
}
