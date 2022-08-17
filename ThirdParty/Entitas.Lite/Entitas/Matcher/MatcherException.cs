using System;

namespace GEntitas {

    public class MatcherException : Exception {
        public MatcherException(int indices) : base(
            "matcher.indices.Length must be 1 but was " + indices) {
        }
    }
}
