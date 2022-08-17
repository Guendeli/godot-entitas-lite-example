using Godot;
using System;
using GEntitas;
using System.Collections.Generic;

namespace Game
{
    public class ShipRenderInitSystem : ReactiveSystem
    {
        private Context _context;
        private const string SHIP_ROOT = "res://Assets/Nodes/Player.tscn"; //

        public ShipRenderInitSystem()
        {
            _context = Contexts.sharedInstance.GetContext<GameContext>();
            monitors += Context<GameContext>.AllOf<ShipComponent>().OnAdded(Process);
        }

        private void Process(List<Entity> entities)
        {
           foreach(Entity shipEntity in entities)
            {
                //Create its visual representation(View)
                Node2D node = GD.Load<PackedScene>(SHIP_ROOT).Instance() as Node2D;
                if (node != null)
                {

                    var currentScene = _context.GetUnique<CurrentSceneComponent>();
                    if (currentScene == null)
                        continue;

                    currentScene.Scene.AddChild(node);
                    
                    GD.Print(string.Format("Loading ship model at {0}", node));
                   
                    shipEntity.AddComponent<ViewComponent>().SetValue(node);
                   
                }
            }
        }
    }
}


