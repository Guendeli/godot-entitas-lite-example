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
        AntiClockwise
    }
}