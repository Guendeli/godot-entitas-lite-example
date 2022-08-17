using Godot;
using System;

using GEntitas;

namespace Game
{
    public class ShipInitSystem : IInitializeSystem
    {
        private readonly Context context;

        public ShipInitSystem()
        {
            this.context = Contexts.sharedInstance.GetContext<GameContext>();
        }

        public void Initialize()
        {
            
            var shipEntity = context.CreateEntity();

            // adding common components
            shipEntity.AddComponent<PositionComponent>().SetValue(Vector2.Zero);
            shipEntity.AddComponent<RotationComponent>().SetValue(0);
            shipEntity.AddComponent<ShipComponent>().SetValue(0);
            shipEntity.AddComponent<AccelerationComponent>().SetValue(1.5f);
            shipEntity.AddComponent<TorqueComponent>().SetValue(15f);
            // adding combat specific components
            shipEntity.AddComponent<BattleEntityTypeComponent>().SetValue(BattleEntityType.Friendly);
            shipEntity.AddComponent<TurretComponent>().SetValue(30);
            shipEntity.AddComponent<LastShotTickComponent>().SetValue(0);
            shipEntity.AddComponent<AttackComponent>().SetValue(10);
        }

    }
}