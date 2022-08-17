﻿namespace GEntitas {

    public interface IEntityIndex {

        string name { get; }

        void Activate();
        void Deactivate();
    }
}
