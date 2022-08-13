using Godot;
using System;
using Entitas;

namespace Game
{
    public class Simulation : Node
    {

        private Contexts _contexts;
        private Systems _feature;

        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {

            _contexts = Contexts.sharedInstance;

            // init systems, auto collect matched systems, no manual Systems.Add(ISystem) required
            
            _feature = new Feature("Game");
            if (_feature != null)
            {
                GD.Print("Initializing feature");
                _feature.Initialize();
            }
        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
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

