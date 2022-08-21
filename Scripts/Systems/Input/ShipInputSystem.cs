using Godot;
using System;
using GEntitas;
using System.Collections.Generic;

namespace Game
{
    public class ShipInputSystem : ReactiveSystem
    {
        private Context _context;

        public ShipInputSystem()
        {
            _context = Contexts.sharedInstance.GetContext<GameContext>();
            monitors += Context<GameContext>.AllOf<InputComponent>().OnAdded(Process);

        }

        private void Process(List<Entity> entities)
        {
            CurrentTickComponent currentTickComponent = _context.GetUnique<CurrentTickComponent>();
            int currentTick = currentTickComponent.Tick;

            for (int i = 0; i < entities.Count; i++)
            {
                Entity inputEntity = entities[i];
                if (inputEntity.HasComponent<DisposeComponent>())
                    continue;

                var shipEntities = Context<GameContext>.AllOf<ShipComponent>().GetEntities();
                if (shipEntities == null || shipEntities.Length == 0)
                    continue;

                Entity shipEntity = shipEntities[0];

                if (!shipEntity.HasComponent<AccelerationComponent>())
                    continue;

               

                GameInputs inputType = inputEntity.GetComponent<InputComponent>().Type;

                switch (inputType)
                {
                    case GameInputs.Accelerate:
                        ProcessAcceleration(shipEntity, 1f);
                        break;
                    case GameInputs.Decelerate:
                        ProcessAcceleration(shipEntity, -1f);
                        break;
                    case GameInputs.ClockWise:
                        ProcessRotation(shipEntity, 1f);

                        break;
                    case GameInputs.AntiClockwise:
                        ProcessRotation(shipEntity, -1f);
                        break;
                    case GameInputs.Shoot:
                        ProcessShooting(shipEntity, currentTick);
                        break;
                    default:
                        break;

                }
                inputEntity.AddComponent<DisposeComponent>();

            }          
        }

        private void ProcessAcceleration(Entity shipEntity, float value)
        {
            float currentAcceleration = shipEntity.GetComponent<AccelerationComponent>().Acceleration;
            if(Mathf.Abs(currentAcceleration) <= 60f)
            {
                currentAcceleration += value * (30f / 60f);
            } else
            {
                currentAcceleration = 60f * value;
            }

            if(currentAcceleration <= 0)
            {
                currentAcceleration = 0; 
            }


            shipEntity.GetComponent<AccelerationComponent>().SetValue(currentAcceleration);
        }

        private void ProcessRotation(Entity shipEntity, float value)
        {
            float torque = shipEntity.GetComponent<TorqueComponent>().Torque;
            if (Mathf.Abs(torque) <= 20f)
            {
                torque += (10f/60f) * value;
            }
            else
            {
                torque = 20f * value;
            }

            shipEntity.GetComponent<TorqueComponent>().SetValue(torque);

        }

        private void ProcessShooting(Entity shipEntity, int currentTick)
        {
            int lastShotTick = shipEntity.GetComponent<LastShotTickComponent>().Tick;
            int rateOfFire = 60;
            if(lastShotTick + rateOfFire <= currentTick)
            {
                Entity projectileEntity = _context.CreateEntity();
                projectileEntity.AddComponent<BattleEntityTypeComponent>().Type = BattleEntityType.Projectile;
                projectileEntity.AddComponent<ProjectileComponent>().SetValue(shipEntity.GetComponent<ShipComponent>().Id, currentTick + 180);
                projectileEntity.AddComponent<AccelerationComponent>().Acceleration = 120f;
                projectileEntity.AddComponent<PositionComponent>().SetValue(shipEntity.GetComponent<PositionComponent>().Position);
                projectileEntity.AddComponent<RotationComponent>().SetValue(shipEntity.GetComponent<RotationComponent>().Rotation);

            }
        }
    }
}

