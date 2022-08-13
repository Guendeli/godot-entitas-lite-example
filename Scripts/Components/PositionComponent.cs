using Godot;
using System;
using Entitas;


// Contexts
public class Game : ContextAttribute
{

}

// Components
[Game]
public class PositionComponent : IComponent
{
    public Vector2 Position;

    public void SetValue(Vector2 newValue)
    {
        this.Position = newValue;
    }
}
