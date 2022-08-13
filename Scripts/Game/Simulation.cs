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
            GD.Print(string.Format("start game"));

            _contexts = Contexts.sharedInstance;

            // init systems, auto collect matched systems, no manual Systems.Add(ISystem) required
            
            _feature = new Feature(null);
            if(_feature != null)
            {
                GD.Print(string.Format("init feature"));

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

