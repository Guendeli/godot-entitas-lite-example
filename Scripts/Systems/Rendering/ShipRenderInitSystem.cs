using Godot;
using System;
using Entitas;
using System.Collections.Generic;

namespace Game
{
    [GameFeature]
    public class ShipRenderInitSystem : ReactiveSystem
    {
        private Context _context;
        private const string SHIP_ROOT = "res://Assets/Nodes/Player.tscn"; //

        public ShipRenderInitSystem()
        {
            monitors += Context<GameContext>.AllOf<ShipComponent>().OnAdded(Process);
        }

        private void Process(List<Entity> entities)
        {
           foreach(Entity shipEntity in entities)
            {
                //Create its visual representation(View)
                GD.Print("Loading ship model");
                Node2D node = GD.Load<PackedScene>(SHIP_ROOT).Instance() as Node2D;
                if (node != null)
                {

                    GD.Print(node.Transform.x);
                    //var view = node.Instance();

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