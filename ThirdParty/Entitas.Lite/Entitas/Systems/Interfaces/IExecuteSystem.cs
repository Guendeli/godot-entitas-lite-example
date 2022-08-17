﻿namespace GEntitas {

    /// Implement this interface if you want to create a system which should be
    /// executed every frame.
    public interface IExecuteSystem : ISystem {

        void Execute();
    }
}
