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

            // Simulation Systems
            Add(new MovementSystem());


            // Render Systems
            Add(new ShipRenderInitSystem());
            Add(new TransformApplySystem());

            // cleanup systems
            Add(new EntityDisposeSystem());
        }
    }

}

