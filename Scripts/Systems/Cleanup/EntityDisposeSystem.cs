using Godot;
using System;
using Entitas;
namespace Game
{
    public class EntityDisposeSystem : IExecuteSystem
    {
        public EntityDisposeSystem()
        {
        }

        public void Execute()
        {
            Entity[] entities = Context<GameContext>.AllOf<DisposeComponent>().GetEntities();

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
