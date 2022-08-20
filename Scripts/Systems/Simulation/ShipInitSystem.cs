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
            shipEntity.AddComponent<PositionComponent>().SetValue(new Vector2(512,300));
            shipEntity.AddComponent<RotationComponent>().SetValue(0);
            shipEntity.AddComponent<ShipComponent>().SetValue(0);
            shipEntity.AddComponent<AccelerationComponent>().SetValue(0);
            shipEntity.AddComponent<TorqueComponent>().SetValue(0);
            // adding combat specific components
            shipEntity.AddComponent<BattleEntityTypeComponent>().SetValue(BattleEntityType.Friendly);
            shipEntity.AddComponent<TurretComponent>().SetValue(30);
            shipEntity.AddComponent<LastShotTickComponent>().SetValue(0);
            shipEntity.AddComponent<AttackComponent>().SetValue(10);
        }

    }
}