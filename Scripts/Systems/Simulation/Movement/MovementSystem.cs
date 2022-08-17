using Godot;
using System;
using GEntitas;

namespace Game
{
    public class MovementSystem : IExecuteSystem
    {
        private IGroup _group;
        public MovementSystem()
        {
            _group = Context<GameContext>.AllOf<PositionComponent, RotationComponent, AccelerationComponent>();
        }

        public void Execute()
        {
            Entity[] entities = _group.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                Entity movableEntity = entities[i];

                Vector2 currentPosition = movableEntity.GetComponent<PositionComponent>().Position;
            }
        }
    }
}

