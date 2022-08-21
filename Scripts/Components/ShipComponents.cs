using Godot;
using System;
using GEntitas;

namespace Game
{
    [GameContext]
    [Serializable]
    public class ShipComponent : IComponent
    {
        public int Id;

        public void SetValue(int newValue)
        {
            this.Id = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class TurretComponent : IComponent
    {
        public int RateOfFire; // in ticks
        public void SetValue(int newValue)
        {
            this.RateOfFire = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class TurretHardpointComponent : IComponent
    {
        public Vector2 Hardpoint; // in ticks
        public void SetValue(Vector2 newValue)
        {
            this.Hardpoint = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class LastShotTickComponent : IComponent
    {
        public int Tick; // in ticks

        public void SetValue(int newValue)
        {
            this.Tick = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class HPComponent : IComponent
    {
        public int HP;

        public void SetValue(int newValue)
        {
            this.HP = newValue;
        }
    }

    [GameContext]
    [Serializable]
    public class AttackComponent : IComponent
    {
        public int Attack;

        public void SetValue(int newValue)
        {
            this.Attack = newValue;
        }
    }

}
