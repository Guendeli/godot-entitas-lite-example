using Godot;
using System;
using GEntitas;
using System.Collections.Generic;

namespace Game
{
    public class ShipInputSystem : ReactiveSystem
    {
        
        public ShipInputSystem()
        {
            monitors += Context<GameContext>.AllOf<InputComponent>().OnAdded(Process);

        }

        private void Process(List<Entity> entities)
        {
            
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

    }
}

