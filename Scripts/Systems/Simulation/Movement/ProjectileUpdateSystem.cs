using Godot;
using System;
using GEntitas;

namespace Game
{
    public class ProjectileUpdateSystem : IExecuteSystem
    {
        private Context _context;
        private IGroup _group;
        public ProjectileUpdateSystem()
        {
            _context = Contexts.sharedInstance.GetContext<GameContext>();
            _group = Context<GameContext>.AllOf<ProjectileComponent>();
        }

        public void Execute()
        {
            CurrentTickComponent currentTickComponent = _context.GetUnique<CurrentTickComponent>();
            int currentTick = currentTickComponent.Tick;
            Entity[] entities = _group.GetEntities();
            for (int i = 0; i < entities.Length; i++)
            {
                Entity projectileEntity = entities[i];

                if (projectileEntity.GetComponent<ProjectileComponent>().Lifetime < currentTick)
                {
                    projectileEntity.AddComponent<DisposeComponent>();
                }


            }
        }
    }
}