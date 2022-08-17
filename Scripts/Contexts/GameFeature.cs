using Godot;
using System;
using GEntitas;

namespace Game
{

    public class GameFeature : Feature { 
        public GameFeature(string name) : base("Game"){

            // Init Systems
            Add(new TickInitializeSystem());
            Add(new TickUpdateSystem());
            Add(new ShipInitSystem());
            // Input Systems


            // Render Systems
            Add(new ShipRenderInitSystem());


            // cleanup systems
            Add(new EntityDisposeSystem());
        }
    }

}

