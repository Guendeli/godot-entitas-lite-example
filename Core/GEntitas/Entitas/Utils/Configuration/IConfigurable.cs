using System.Collections.Generic;

namespace GEntitas.Utils {

    public interface IConfigurable {

        Dictionary<string, string> defaultProperties { get; }

        void Configure(Preferences preferences);
    }
}
