using Godot;
using System;
using Entitas;

namespace Game
{
    public class Simulation : Node
    {

        private Contexts _contexts;
        private Systems _feature;

        
        public override void _Ready()
        {

            _contexts = Contexts.sharedInstance;

            var rootScene = GetTree().Root;
            var sceneEntity = _contexts.GetContext<GameContext>().CreateEntity();
            sceneEntity.Add<CurrentSceneComponent>().SetValue(rootScene);

            _feature = new GameFeature("Game");
            if (_feature != null)
            {
                GD.Print("Initializing feature");
                _feature.Initialize();
            }
        }

          public override void _Process(float delta)
          {
            if(_feature != null)
            {
                _feature.Execute();
                _feature.Cleanup();
            }
           
          }
    }
}

