using Godot;
using System;
using GEntitas;

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

        public override void _Input(InputEvent inputEvent)
        {
            if (inputEvent.IsAction("ui_up"))
            {
                var input = _contexts.GetContext<GameContext>().CreateEntity();
                input.Add<InputComponent>().SetValue(GameInputs.Accelerate);
            }

            if (inputEvent.IsAction("ui_down"))
            {
                var input = _contexts.GetContext<GameContext>().CreateEntity();
                input.Add<InputComponent>().SetValue(GameInputs.Decelerate);
            }

            if (inputEvent.IsAction("ui_right"))
            {
                var input = _contexts.GetContext<GameContext>().CreateEntity();
                input.Add<InputComponent>().SetValue(GameInputs.ClockWise);
            }

            if (inputEvent.IsAction("ui_left"))
            {
                var input = _contexts.GetContext<GameContext>().CreateEntity();
                input.Add<InputComponent>().SetValue(GameInputs.AntiClockwise);
            }
        }
    }
}

