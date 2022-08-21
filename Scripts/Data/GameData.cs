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
        public float Torque;
        public float MaxTorque;
        public float Drag;                  // how much the ship decelerates each tick
        public float AngularDrag;           // same as above but for torque
        public int Attack;
        public int RateOfFire;              // how many ticks between each fire
        public string PrefabRootName;       // in case designers want full control over visuals
    }
}