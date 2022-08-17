using Godot;
using System;
using GEntitas;
namespace Game
{
    public class EntityDisposeSystem : IExecuteSystem
    {
        private IGroup _group;
        public EntityDisposeSystem()
        {
            _group = Context<GameContext>.AllOf<DisposeComponent>();
        }

        public void Execute()
        {
            Entity[] entities = _group.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                Entity disposeEntity = entities[i];
                if (disposeEntity.Has<ViewComponent>())
                {
                    var view = disposeEntity.GetComponent<ViewComponent>().View;
                    if(view != null)
                    {
                        view.QueueFree(); 
                    }
                }

                disposeEntity.Destroy();
            }
        }
    }

}
