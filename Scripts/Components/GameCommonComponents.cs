using Godot;
using System;
using Entitas;

namespace Game
{
    // Components
    [GameContext]
    public class PositionComponent : IComponent
    {
        public Vector2 Position;

        public void SetValue(Vector2 newValue)
        {
            this.Position = newValue;
        }
    }
}
