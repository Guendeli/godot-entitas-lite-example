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
                float acceleration = movableEntity.GetComponent<AccelerationComponent>().Acceleration;
                float rotation = movableEntity.GetComponent<RotationComponent>().Rotation;
                // get the forward vector

                Vector2 forward = new Vector2(Mathf.Cos(rotation + Mathf.Deg2Rad(90)), Mathf.Sin(Mathf.Deg2Rad(90)));

                Vector2 delta = (forward * acceleration) / 60f;
                movableEntity.GetComponent<PositionComponent>().Position = currentPosition + delta;
                movableEntity.Modify<PositionComponent>(); // FLAG FOR REACTIVE SYSTEM

                if (!movableEntity.HasComponent<TorqueComponent>())
                    continue;

                float torque = movableEntity.GetComponent<TorqueComponent>().Torque;

                movableEntity.GetComponent<RotationComponent>().SetValue(rotation + (torque / 60f));
                movableEntity.Modify<RotationComponent>(); // FLAG FOR REACTIVE SYSTEM

            }
        }
    }
}

