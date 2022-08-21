using Godot;
using System;
using GEntitas;

namespace Game
{
    [GameContext]
    [Serializable]
    public class ProjectileComponent : IComponent
    {
        public int ParentId;
        public int Lifetime;

        public void SetValue(int parent, int lifeTime)
        {
            ParentId = parent;
            Lifetime = lifeTime;
        }
    }
}
