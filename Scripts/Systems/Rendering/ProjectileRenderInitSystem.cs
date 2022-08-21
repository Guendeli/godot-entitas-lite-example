using Godot;
using System; //
using GEntitas;
using System.Collections.Generic;

namespace Game
{
    public class ProjectileRenderInitSystem : ReactiveSystem
    {
        private Context _context;
        private const string PROJECTILE_ROOT = "res://Assets/Nodes/cannon.tscn"; //

        public ProjectileRenderInitSystem()
        {
            _context = Contexts.sharedInstance.GetContext<GameContext>();
            monitors += Context<GameContext>.AllOf<ProjectileComponent>().OnAdded(Process);
        }

        private void Process(List<Entity> entities)
        {
            foreach (Entity projectileEntity in entities)
            {
                //Create its visual representation(View)
                Node2D node = GD.Load<PackedScene>(PROJECTILE_ROOT).Instance() as Node2D;
                if (node != null)
                {

                    var currentScene = _context.GetUnique<CurrentSceneComponent>();
                    if (currentScene == null)
                        continue;

                    currentScene.Scene.AddChild(node);

                    projectileEntity.AddComponent<ViewComponent>().SetValue(node);

                }
            }
        }
    }
}