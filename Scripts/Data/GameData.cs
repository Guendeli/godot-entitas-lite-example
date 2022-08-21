using Godot;
using System;

namespace Game
{
    public enum BattleEntityType
    {
        Friendly,
        Projectile,
        Hostile
    }

    public enum GameInputs
    {
        Accelerate,
        Decelerate,
        ClockWise,
        AntiClockwise,
        Shoot
    }


    [Serializable]
    public class ShipModel
    {
        public int ShipId = 0;                  // Id of the ship, we can have multiples (Events ? Gacha ? IAP ? Unlockable)
        public int HP = 100;
        public float Acceleration = 30f;
        public float MaxAcceleration = 60f;
        public float Torque = 5f;
        public float MaxTorque = 10f;
        public float Drag = 0f;                  // how much the ship decelerates each tick
        public float AngularDrag = 2.5f;           // same as above but for torque
        public int Attack = 42;
        public int RateOfFire = 30;              // how many ticks between each fire
        public string PrefabRootName = "";       // in case designers want full control over visuals
    }
}