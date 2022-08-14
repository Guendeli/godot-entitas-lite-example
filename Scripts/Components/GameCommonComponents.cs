using Godot;
using System;
using Entitas;

namespace Game
{

    [GameContext]
    [Serializable]
    public class BattleEntityTypeComponent : IComponent
    {
        public BattleEntityType Type;
        public void SetValue(BattleEntityType newValue)
        {
            this.Type = newValue;
        }
    }

    // Components
    [GameContext][Serializable]
    public class PositionComponent : IComponent
    {
        public Vector2 Position;

        public void SetValue(Vector2 newValue)
        {
            this.Position = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class RotationComponent : IComponent
    {
        public Quat Rotation;
        public void SetValue(Quat newValue)
        {
            this.Rotation = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class AccelerationComponent : IComponent
    {
        public float Acceleration;

        public void SetValue(float newValue)
        {
            this.Acceleration = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class TorqueComponent : IComponent
    {
        public float Torque;

        public void SetValue(float newValue)
        {
            this.Torque = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class ViewComponent : IComponent
    {
        public Node View;
    }


    [GameContext]
    [Serializable]
    public class CurrentTickComponent : IUnique, IComponent
    {
        public int Tick;

        public void SetValue(int newValue)
        {
            this.Tick = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class CurrentSceneComponent : IUnique, IComponent
    {
        public Node Scene;

        public void SetValue(Node newValue)
        {
            this.Scene = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class DisposeComponent : IComponent
    {

    }
}
