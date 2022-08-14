using Godot;
using System;
using Entitas;

namespace Game
{
    public class TickInitializeSystem : IInitializeSystem
    {
        public TickInitializeSystem()
        {

        }

        public void Initialize()
        {
            GD.Print(string.Format("Init system tick Init"));
            float secondsSinceStartup = GetRealTimeSinceStartup();
            var tick = Contexts.sharedInstance.GetContext<GameContext>().CreateEntity();
            int currentTick = (int)(secondsSinceStartup * 60);
            tick.AddComponent<CurrentTickComponent>().SetValue(currentTick);

            GD.Print(string.Format("Starting Game at {0}", currentTick));
        }

        private float GetRealTimeSinceStartup()
        {
            float secondsSinceStartup = Time.GetTicksMsec() / 1000.0f;

            return secondsSinceStartup;

        }
    }

    public class TickUpdateSystem : IExecuteSystem
    {
        private Context _context;

        public TickUpdateSystem()
        {
            _context = Contexts.sharedInstance.GetContext<GameContext>();
        }

        public void Execute()
        {
            CurrentTickComponent currentTickComponent = _context.GetUnique<CurrentTickComponent>();
            if (currentTickComponent != null)
            {
                int currentTick = currentTickComponent.Tick;
                float realtimeSinceStartup = GetRealTimeSinceStartup();
                float tickToSeconds = (currentTick) / 60f;
                float step = 16 / 60f;
                if (realtimeSinceStartup > tickToSeconds + step)
                {

                    currentTick++;
                    currentTickComponent.SetValue(currentTick);
                }

            }
        }

        private float GetRealTimeSinceStartup()
        {
            float secondsSinceStartup = Time.GetTicksMsec() / 1000.0f;

            return secondsSinceStartup;

        }
    }
}

