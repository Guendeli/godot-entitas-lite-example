using Godot;
using System;
using GEntitas;

namespace Game
{
    public class ShipDecelerationSystem : IExecuteSystem
    {
        private Context _context;
        private IGroup _group;

        public ShipDecelerationSystem()
        {
            _group = Context<GameContext>.AllOf<ShipComponent>();
        }

        public void Execute()
        {
            Entity[] entities = _group.GetEntities();
            for (int i = 0; i < entities.Length; i++)
            {
                Entity shipEntity = entities[i];

                float currentAccel = shipEntity.GetComponent<AccelerationComponent>().Acceleration;
                float currentTorque = shipEntity.GetComponent<TorqueComponent>().Torque;

                // Deceleration part


                // angular drag part
                float dir = Mathf.Sign(currentTorque);
                currentTorque -= (2.5f/60f) * dir;
                if (Mathf.Abs(currentTorque) <= 0)
                {
                    currentTorque = 0;
                }

                shipEntity.GetComponent<TorqueComponent>().SetValue(currentTorque);
                shipEntity.Modify<TorqueComponent>();
            }
        }
    }

}
