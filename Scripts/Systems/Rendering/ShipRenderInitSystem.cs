using Godot;
using System;
using Entitas;
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
                    GD.Print(string.Format("Loading ship model at {0}", node.Transform.x));
                   
                    //shipEntity.AddView(view);
                    //Renderer renderer = view.GetComponentInChildren<Renderer>();
                    //if (renderer != null)
                    //{
                    //    Bounds bounds = renderer.bounds;
                    //    shipEntity.AddBounds(bounds);
                    //}
                }
            }
        }
    }
}


//public ShipRenderInitSystem(Contexts context) : base(context.game)
//{
//    _context = context.game;
//}

//protected override void Execute(List<GameEntity> entities)
//{
//    foreach (GameEntity shipEntity in entities)
//    {
//        // Create its visual representation (View)
//        GameObject view = GameObject.Instantiate(Resources.Load<GameObject>(string.Format(SHIP_ROOT, shipEntity.ship.Id)));
//        if (view != null)
//        {
//            shipEntity.AddView(view);
//            Renderer renderer = view.GetComponentInChildren<Renderer>();
//            if (renderer != null)
//            {
//                Bounds bounds = renderer.bounds;
//                shipEntity.AddBounds(bounds);
//            }
//        }

//    }
//}

//protected override bool Filter(GameEntity entity)
//{
//    return entity.hasShip;
//}

//protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//{
//    return context.CreateCollector(GameMatcher.Ship);
//}