using System;

namespace GEntitas {

    /// Base exception used by Entitas.
    public class EntitasException : Exception {

        public EntitasException(string message, string hint)
            : base(hint != null ? (message + "\n" + hint) : message) {
        }
    }
}
