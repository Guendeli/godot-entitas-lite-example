using Godot;
using System;
using GEntitas;

namespace Game
{
    public class TransformApplySystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup _group;

        public TransformApplySystem()
        {
            _group = Context<GameContext>.AllOf<PositionComponent, RotationComponent, ViewComponent>();

        }

        public void Execute()
        {
            Entity[] entities = _group.GetEntities();
            for (int i = 0; i < entities.Length; i++)
            {
                Entity viewEntity = entities[i];
                Node2D gameObject = viewEntity.GetComponent<ViewComponent>().View as Node2D;
                if (gameObject == null)
                    continue;
                float rotation = viewEntity.GetComponent<RotationComponent>().Rotation;
                Vector2 position = viewEntity.GetComponent<PositionComponent>().Position;


                gameObject.Transform = new Transform2D(rotation, position);
            }

        }

    }
}

